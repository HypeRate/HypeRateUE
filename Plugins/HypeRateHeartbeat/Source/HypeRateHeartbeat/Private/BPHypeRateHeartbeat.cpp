// Fill out your copyright notice in the Description page of Project Settings.

#include "BPHypeRateHeartbeat.h"

bool UBPHypeRateHeartbeat::isConnected = false;
int UBPHypeRateHeartbeat::lastHeartBeat = 80;
TSharedPtr<IWebSocket> UBPHypeRateHeartbeat::Socket = nullptr;
std::thread UBPHypeRateHeartbeat::thr = std::thread([]{

    while (true) {
        if (UBPHypeRateHeartbeat::isConnected) {
            UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Ping?"));
            if (UBPHypeRateHeartbeat::Socket->IsConnected()) {
                UBPHypeRateHeartbeat::Socket->Send("{\"topic\": \"phoenix\",\"event\": \"heartbeat\",\"payload\": {},\"ref\": 0}");
                UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Ping"));
            }
        }
        std::this_thread::sleep_for(std::chrono::milliseconds(20 * 1000));
    }
    });


void UBPHypeRateHeartbeat::Connect(FString Topic, FString WebsocketKey)
{
    if (isConnected) return;
    isConnected = true;
    FString ServerURL = FString("wss://app.hyperate.io/socket/websocket?token=" + WebsocketKey);

    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] URI %s"), *ServerURL);
    const FString ServerProtocol = TEXT("wss");              // The WebServer protocol you want to use.

    Socket = FWebSocketsModule::Get().CreateWebSocket(ServerURL, ServerProtocol);
    Socket->OnConnected().AddLambda([ Topic]() -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnConnected"));

        FString s = FString("{\"topic\": \"hr:" + Topic + "\", \"event\": \"phx_join\",\"payload\": {},\"ref\": 0}");
        Socket->Send(s);
        });

    Socket->OnClosed().AddLambda([](int32 StatusCode, const FString& Reason, bool bWasClean) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Connection to websocket server has been closed with status code: \"%d\" and reason: \"%s\"."), StatusCode, *Reason);
        });

    Socket->OnMessage().AddLambda([](const FString& Message) -> void {
        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnMessage %s"), *Message);
        TSharedPtr<FJsonObject> JsonParsed;
        TSharedRef<TJsonReader<TCHAR>> JsonReader = TJsonReaderFactory<TCHAR>::Create(*Message);
        if (FJsonSerializer::Deserialize(JsonReader, JsonParsed)) {
            FString event = JsonParsed->GetStringField("event");
            if (event != "hr_update") return;
            TSharedPtr<FJsonObject> payload = JsonParsed->GetObjectField("payload");
            int hr = payload->GetIntegerField("hr");

            UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] OnMessage hr %s"), *FString::FromInt(hr));
            lastHeartBeat = hr;
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
    return lastHeartBeat;
}

void UBPHypeRateHeartbeat::Disconnect() {
    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Closing"));
    if (!Socket->IsConnected()) return;
    isConnected = false;
    Socket->Close();
    //thr.join();
    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::DEV] Closed"));
}

