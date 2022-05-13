// Fill out your copyright notice in the Description page of Project Settings.

#define HypeRateUseSecure1

#ifdef HypeRateUseSecure
    FString furi = "ws://staging.frightrate.com/socket/websocket?token=" + UBPHypeRateHeartbeat::FWebsocketKey;
#else
    FString furi = "ws://localhost:8080";
#endif

#include "BPHypeRateHeartbeat.h"

using websocketpp::lib::placeholders::_1;
using websocketpp::lib::placeholders::_2;
using websocketpp::lib::bind;

std::vector<std::string> split(std::string str, std::string sep) {
    char* cstr = const_cast<char*>(str.c_str());
    char* current;
    std::vector<std::string> arr;
    current = strtok(cstr, sep.c_str());
    while (current != NULL) {
        arr.push_back(current);
        current = strtok(NULL, sep.c_str());
    }
    return arr;
}

int UBPHypeRateHeartbeat::ping_counter = 0;

void UBPHypeRateHeartbeat::on_message(client* c, websocketpp::connection_hdl hdl, message_ptr msg) {
    const char* s = msg->get_payload().c_str();
    // s = {"event":"hr_update","payload":{"hr":60},"ref":null,"topic":"hr:internal-testing"}
    FString rawstring(s);
    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::IN::MESSAGE]: %s"), *rawstring);
    // splitting s -> 60},"ref" -> 60
    std::vector<std::string> out = split(split(s, ":")[3].c_str(),"}");
    FString heartbeat(out[0].c_str());
    UE_LOG(LogTemp, Log, TEXT("[HYPERATE::IN::HEARTBEAT] %s"), *heartbeat);
    int i;
    if (sscanf(out[0].c_str(), "%d", &i) != 1) {}
    UBPHypeRateHeartbeat::lastHeartBeat = i;

    UBPHypeRateHeartbeat::ping_counter = (UBPHypeRateHeartbeat::ping_counter + 1) % 25;
    if (UBPHypeRateHeartbeat::ping_counter == 0) {
        std::string msg = "{\"topic\": \"phoenix\",\"event\": \"heartbeat\",\"payload\": {},\"ref\": 0}";
        FString temp = UTF8_TO_TCHAR(msg.c_str());

        UE_LOG(LogTemp, Log, TEXT("[HYPERATE::OUT::PING] %s"), *temp);

        websocketpp::lib::error_code ec1;
        clt.send(hdl, msg.c_str(), websocketpp::frame::opcode::text, ec1);
        if (ec1) {
            FString estr = UTF8_TO_TCHAR(ec1.message().c_str());
            UE_LOG(LogTemp, Error, TEXT("[HYPERATE::OUT::PING::ERROR] %s"), *estr);
        }
        else UE_LOG(LogTemp, Log, TEXT("[HYPERATE::OUT::PING::SUCCESS]"));
    }
}

int UBPHypeRateHeartbeat::lastHeartBeat = 80;

client UBPHypeRateHeartbeat::clt{};
FString UBPHypeRateHeartbeat::FTopic = "";
FString UBPHypeRateHeartbeat::FWebsocketKey = "";

void on_open(client* c, websocketpp::connection_hdl hdl) {
    UE_LOG(LogTemp, Warning, TEXT("Websocket on_open"));
}


//void UBPHypeRateHeartbeat::on_socket_init(client* c, websocketpp::connection_hdl hdl){
void UBPHypeRateHeartbeat::on_socket_init(websocketpp::connection_hdl hdl, boost::asio::ip::tcp::socket& s){
    UE_LOG(LogTemp, Warning, TEXT("on_socket_init Init"));
    try {
        //boost::asio::ip::tcp::no_delay option(true);
        boost::asio::ip::tcp::no_delay option(true);
        s.set_option(option);
    }catch(...){
        UE_LOG(LogTemp, Warning, TEXT("on_socket_init err"));
    }
    
    //sendLogin(hdl);
};

void UBPHypeRateHeartbeat::sendLogin(websocketpp::connection_hdl hdl) {
    UE_LOG(LogTemp, Warning, TEXT("Websocket Init option set"));

    std::string hr(TCHAR_TO_UTF8(*UBPHypeRateHeartbeat::FTopic));
    std::string msg = "{\"topic\": \"hr:" + hr + "\",\"event\": \"phx_join\",\"payload\": {},\"ref\": 0}";
    FString temp = UTF8_TO_TCHAR(msg.c_str());

    UE_LOG(LogTemp, Log, TEXT("Websocket Init Login sending %s"), *temp);

    websocketpp::lib::error_code ec1;
    clt.send(hdl, msg.c_str(), websocketpp::frame::opcode::text, ec1);
    if (ec1) {
        FString estr = UTF8_TO_TCHAR(ec1.message().c_str());
        UE_LOG(LogTemp, Log, TEXT("Websocket Init Login error %s"), *estr);
    }
    else UE_LOG(LogTemp, Log, TEXT("Websocket Init Login sent"));
}

void UBPHypeRateHeartbeat::on_open(websocketpp::connection_hdl){
    UE_LOG(LogTemp, Log, TEXT("Websocket Open"));
};
void UBPHypeRateHeartbeat::on_close(client* c, websocketpp::connection_hdl hdl){
    UE_LOG(LogTemp, Error, TEXT("Websocket Close"));
};
void UBPHypeRateHeartbeat::on_fail(client* c, websocketpp::connection_hdl hdl){
    UE_LOG(LogTemp, Error, TEXT("Websocket Failed"));
};


#ifdef HypeRateUseSecure
typedef std::shared_ptr<boost::asio::ssl::context> context_ptr;
static context_ptr on_tls_init() {
    // establishes a SSL connection
    context_ptr ctx = std::make_shared<boost::asio::ssl::context>(boost::asio::ssl::context::sslv23);

    try {
        ctx->set_options(boost::asio::ssl::context::default_workarounds |
            boost::asio::ssl::context::no_sslv2 |
            boost::asio::ssl::context::no_sslv3 |
            boost::asio::ssl::context::single_dh_use);
    }
    catch (std::exception& e) {
        std::cout << "Error in context pointer: " << e.what() << std::endl;
    }
    return ctx;
}
#endif

void s1() {
    std::string uri(TCHAR_TO_UTF8(*furi));
    UE_LOG(LogTemp, Warning, TEXT("Connecting to %s"), *furi);
    // Create a client endpoint

    try {
        // Set logging to be pretty verbose (everything except message payloads)
        UBPHypeRateHeartbeat::clt.set_access_channels(websocketpp::log::alevel::all);
        UBPHypeRateHeartbeat::clt.set_error_channels(websocketpp::log::elevel::all);
        UBPHypeRateHeartbeat::clt.clear_access_channels(websocketpp::log::alevel::frame_payload);
        //*

        // Initialize ASIO
        UBPHypeRateHeartbeat::clt.init_asio();

        // Register our message handler
        UBPHypeRateHeartbeat::clt.set_message_handler(bind(&UBPHypeRateHeartbeat::on_message, &UBPHypeRateHeartbeat::clt, ::_1, ::_2));
#ifdef HypeRateUseSecure
        UBPHypeRateHeartbeat::clt.set_tls_init_handler(bind(&on_tls_init));
#else
        UBPHypeRateHeartbeat::clt.set_socket_init_handler(bind(&UBPHypeRateHeartbeat::on_socket_init, ::_1, ::_2));
#endif

        UBPHypeRateHeartbeat::clt.set_close_handler(bind(&UBPHypeRateHeartbeat::on_close, &UBPHypeRateHeartbeat::clt, ::_1));

        UBPHypeRateHeartbeat::clt.set_fail_handler(bind(&UBPHypeRateHeartbeat::on_fail, &UBPHypeRateHeartbeat::clt, ::_1));

        websocketpp::lib::error_code ec;
        client::connection_ptr con  = UBPHypeRateHeartbeat::clt.get_connection(uri, ec);
        if (ec) {
            FString test = UTF8_TO_TCHAR(ec.message().c_str());
            UE_LOG(LogTemp, Error, TEXT("Init (ec) could not create connection because: %s"), *test);
            return;
        }
        UE_LOG(LogTemp, Log, TEXT("Init (no ec)"));


        // Note that connect here only requests a connection. No network messages are
        // exchanged until the event loop starts running in the next line.
        UBPHypeRateHeartbeat::clt.connect(con);


        // Start the ASIO io_service run loop
        // this will cause a single connection to be made to the server. c.run()
        // will exit when this connection is closed.
        UBPHypeRateHeartbeat::clt.run();
    }
    catch (websocketpp::exception const& e) {
        FString test = UTF8_TO_TCHAR(e.what());
        UE_LOG(LogTemp, Warning, TEXT("Init (catch) %s"),*test);
    }
};

FMyWorker* UBPHypeRateHeartbeat::Worker;

void UBPHypeRateHeartbeat::HeartBeat(FString Topic, FString WebsocketKey)
{
    FTopic = Topic;
    FWebsocketKey = WebsocketKey;

    Worker = new FMyWorker();
    UE_LOG(LogTemp, Warning, TEXT("Thread stopping"));
}

int random(int min, int max) //range : [min, max]
{
    static bool first = true;
    if (first)
    {
        srand(time(NULL)); //seeding for the first time only!
        first = false;
    }
    return min + rand() % ((max + 1) - min);
}

int UBPHypeRateHeartbeat::GetHeartBeat()
{
    return UBPHypeRateHeartbeat::lastHeartBeat;
}

FMyWorker::FMyWorker(/* You can pass in inputs here */)
{
    // Constructs the actual thread object. It will begin execution immediately
    // If you've passed in any inputs, set them up before calling this.
    UE_LOG(LogTemp, Warning, TEXT("[FMyWorker] Construct!"));
    Thread = FRunnableThread::Create(this, TEXT("Give your thread a good name"),0, TPri_Highest);
}


FMyWorker::~FMyWorker()
{
    UE_LOG(LogTemp, Warning, TEXT("[FMyWorker] Destruct!"));
    if (Thread)
    {
        // Kill() is a blocking call, it waits for the thread to finish.
        // Hopefully that doesn't take too long
        Thread->Kill();
        delete Thread;
    }
}

bool FMyWorker::Init()
{
    UE_LOG(LogTemp, Warning, TEXT("[FMyWorker] init!"));
        //s();
        // Return false if you want to abort the thread
        return true;
}


uint32 FMyWorker::Run()
{
    UE_LOG(LogTemp, Warning, TEXT("[FMyWorker] run!"));
    // Peform your processor intensive task here. In this example, a neverending
    // task is created, which will only end when Stop is called.
    /*while (bRunThread)
    {
        UE_LOG(LogTemp, Warning, TEXT("My custom thread is running!"));
            FPlatformProcess::Sleep(1.0f);
    }*/
    s1();

    return 0;
}


// This function is NOT run on the new thread!
void FMyWorker::Stop()
{
    UE_LOG(LogTemp, Warning, TEXT("[FMyWorker] stop!"));
    // Clean up memory usage here, and make sure the Run() function stops soon
    // The main thread will be stopped until this finishes!

    // For this example, we just need to terminate the while loop
    // It will finish in <= 1 sec, due to the Sleep()
    bRunThread = false;
}