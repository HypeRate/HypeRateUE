// Fill out your copyright notice in the Description page of Project Settings.

#define HypeRateUseSecure1

#include "BPHypeRateHeartbeat.h"
#include "Json.h"
#include <Runtime/Online/WebSockets/Public/WebSocketsModule.h>
#include <Runtime/Online/WebSockets/Public/IWebSocket.h>

int UBPHypeRateHeartbeat::ping_counter = 0;
int UBPHypeRateHeartbeat::lastHeartBeat = 80;

void UBPHypeRateHeartbeat::HeartBeat(FString Topic, FString WebsocketKey)
{
    #ifdef HypeRateUseSecure
        FString ServerURL = "wss://app.hyperate.io/socket/websocket?token=" + WebsocketKey;
    #else
        FString ServerURL = "ws://localhost:8080";
    #endif

    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] URI %s"), *ServerURL);
    const FString ServerProtocol = TEXT("");              // The WebServer protocol you want to use.

    TSharedPtr<IWebSocket> Socket = FWebSocketsModule::Get().CreateWebSocket(ServerURL, ServerProtocol);
    // We bind all available events
    Socket->OnConnected().AddLambda([Socket, Topic]() -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnConnected"));
        Socket->Send("{\"topic\": \"hr:"+Topic+", \"event\": \"phx_join\",\"payload\": {},\"ref\": 0}");
        });

    Socket->OnClosed().AddLambda([](int32 StatusCode, const FString& Reason, bool bWasClean) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Connection to websocket server has been closed with status code: \"%d\" and reason: \"%s\"."), StatusCode, *Reason);
        });

    Socket->OnMessage().AddLambda([Socket](const FString& Message) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnMessage %s"), *Message);
        TSharedPtr<FJsonObject> JsonParsed;
        TSharedRef<TJsonReader<TCHAR>> JsonReader = TJsonReaderFactory<TCHAR>::Create(*Message);
        if (FJsonSerializer::Deserialize(JsonReader, JsonParsed)){
            TSharedPtr<FJsonObject> payload = JsonParsed->GetObjectField("payload");
            FString hr = payload->GetStringField("hr");

            UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnMessage hr %s"), *hr);
            UBPHypeRateHeartbeat::lastHeartBeat = FCString::Atoi(*hr);
        }
        UBPHypeRateHeartbeat::ping_counter = (UBPHypeRateHeartbeat::ping_counter + 1) % 25;
        if (UBPHypeRateHeartbeat::ping_counter == 0) {
            if (!Socket->IsConnected()){ return; }
            Socket->Send("{\"topic\": \"phoenix\",\"event\": \"heartbeat\",\"payload\": {},\"ref\": 0}");
        }
        });

    Socket->OnMessageSent().AddLambda([](const FString& MessageString) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnMessageSent"));
        });

    Socket->OnConnectionError().AddLambda([](const FString& Error) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnConnectionError %s"), *Error);
        });

    Socket->Connect();
}


int UBPHypeRateHeartbeat::GetHeartBeat()
{
    return UBPHypeRateHeartbeat::lastHeartBeat;
}
