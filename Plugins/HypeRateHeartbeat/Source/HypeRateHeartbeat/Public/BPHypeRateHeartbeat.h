// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
//#define ASIO_STANDALONE

#include "CoreMinimal.h"
#include "Analytics.h"
#include "Kismet/BlueprintFunctionLibrary.h"

#include <websocketpp/client.hpp>

#ifdef HypeRateUseSecure
#include <websocketpp/config/asio_client.hpp>
typedef websocketpp::client<websocketpp::config::asio_tls_client> client;
typedef websocketpp::config::asio_tls_client::message_type::ptr message_ptr;
#else
#include <websocketpp/config/asio_no_tls_client.hpp>
typedef websocketpp::client<websocketpp::config::asio_client> client;
typedef websocketpp::config::asio_client::message_type::ptr message_ptr;
#endif

#include "HAL/Runnable.h"

#include <string>
#include <iostream>
#include <boost/random/random_device.hpp>

#define strcasecmp stricmp
#define WIN32_LEAN_AND_MEAN

#include "BPHypeRateHeartbeat.generated.h"

class HYPERATEHEARTBEAT_API FMyWorker : public FRunnable
{
public:

	// Constructor, create the thread by calling this
	FMyWorker();

	// Destructor
	virtual ~FMyWorker() override;


	// Overriden from FRunnable
	// Do not call these functions youself, that will happen automatically
	bool Init() override; // Do your setup here, allocate memory, ect.
	uint32 Run() override; // Main data processing happens here
	void Stop() override; // Clean up any memory you allocated here


private:

	// Thread handle. Control the thread using this, with operators like Kill and Suspend
	FRunnableThread* Thread;

	// Used to know when the thread should exit, changed in Stop(), read in Run()
	bool bRunThread;
};

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

	static client m_endpoint;

	static void on_message(client* c, websocketpp::connection_hdl hdl, message_ptr msg);
	//static void on_socket_init(client* c, websocketpp::connection_hdl hdl);
	static void on_socket_init(websocketpp::connection_hdl, boost::asio::ip::tcp::socket& s);
	static void on_open(websocketpp::connection_hdl hdl);
	static void on_close(client* c, websocketpp::connection_hdl hdl);
	static void on_fail(client* c, websocketpp::connection_hdl hdl);
	static void sendLogin(websocketpp::connection_hdl hdl);

	static client clt;

	static FString FTopic;
	static FString FWebsocketKey;

	static FMyWorker* Worker;

	static int ping_counter;
};
