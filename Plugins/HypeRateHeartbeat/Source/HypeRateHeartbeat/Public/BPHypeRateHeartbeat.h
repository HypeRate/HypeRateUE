// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Analytics.h"
#include "Kismet/BlueprintFunctionLibrary.h"

#include "HAL/Runnable.h"

#include <string>
#include <iostream>

#include "BPHypeRateHeartbeat.generated.h"

/**
 *
 */
UCLASS()
class HYPERATEHEARTBEAT_API UBPHypeRateHeartbeat : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
public:
	UFUNCTION(BlueprintCallable, Category = "AAHype Rate")
		static void HeartBeat(FString Topic, FString WebsocketKey);

	UFUNCTION(BlueprintCallable, Category = "AAHype Rate")
		static int GetHeartBeat();

	static int lastHeartBeat;

	static int ping_counter;
};
