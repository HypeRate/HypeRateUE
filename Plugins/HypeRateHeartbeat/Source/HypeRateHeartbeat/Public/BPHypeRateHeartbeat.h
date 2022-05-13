// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "Json.h"
#include <Runtime/Online/WebSockets/Public/WebSocketsModule.h>
#include <Runtime/Online/WebSockets/Public/IWebSocket.h>
#include <thread>

#include "BPHypeRateHeartbeat.generated.h"

/**
 *
 */
UCLASS()
class HYPERATEHEARTBEAT_API UBPHypeRateHeartbeat : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
public:
	UFUNCTION(BlueprintCallable, Category = "Hype Rate")
		 static void Connect(FString Topic, FString WebsocketKey);

	UFUNCTION(BlueprintCallable, Category = "Hype Rate")
		static int GetHeartBeat();

	UFUNCTION(BlueprintCallable, Category = "Hype Rate")
		static void Disconnect();

	static int lastHeartBeat;

	static bool isConnected;

	static TSharedPtr<IWebSocket> Socket;
};
