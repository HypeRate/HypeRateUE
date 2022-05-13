var WebSocketClient = require('websocket').client;
var WebSocketServer = require('websocket').server;
var {key,topic} = require("./config.js")
const url = 'wss://staging.frightrate.com/socket/websocket?token='+key
let n = 0;

var http = require('http');

var server = http.createServer(function(request, response) {
    console.log((new Date()) + ' Received request for ' + request.url);
    response.writeHead(404);
    response.end();
});
server.listen(8080, function() {
    console.log((new Date()) + ' Server is listening on port 8080');
});

wsServer = new WebSocketServer({
    httpServer: server,
    // You should not use autoAcceptConnections for production
    // applications, as it defeats all standard cross-origin protection
    // facilities built into the protocol and the browser.  You should
    // *always* verify the connection's origin and decide whether or not
    // to accept it.
    autoAcceptConnections: false
});

function originIsAllowed(origin) {
  // put logic here to detect whether the specified origin is allowed.
  return true;
}

const connections = []


wsServer.on('request', function(request) {
    if (!originIsAllowed(request.origin)) {
      // Make sure we only accept requests from an allowed origin
      request.reject();
      console.log((new Date()) + ' Connection from origin ' + request.origin + ' rejected.');
      return;
    }
    console.log("requestedProtocols="+request.requestedProtocols)
    
    var connection = request.accept('', request.origin);
    console.log((new Date()) + ' Connection accepted.');
    connections.push(connection)
    connection.on('close', function(reasonCode, description) {
        console.log((new Date()) + ' Peer ' + connection.remoteAddress + ' disconnected.');
        connections.splice(connections.indexOf(connection), 1)
    });
});

var client = new WebSocketClient();
client.on('connectFailed', function(error) {
    console.log('Connect Error: ' + error.toString());
});
client.on('connect', function(connection) {
    console.log('WebSocket Client Connected');
    connection.on('error', function(error) {
        console.log("Connection Error: " + error.toString());
    });
    connection.on('close', function() {
        console.log('chat Connection Closed');
    });
    connection.on('message', function(message) {
        const data = JSON.parse(message.utf8Data)
        if(data.event==='hr_update') {
            n++;
            console.log(data.payload.hr,n);
            connections.forEach(connection => connection.sendUTF(message.utf8Data))
        }
    });
    connection.sendUTF(JSON.stringify({"topic": "hr:"+topic,"event": "phx_join","payload": {},"ref": 0}))
    setInterval(()=>{
        n=0;
        connection.sendUTF(JSON.stringify({"topic": "phoenix","event": "heartbeat","payload": {},"ref": 0}))
    },30*1000)
});
client.connect(url);

// setTimeout(()=>{
//     var client2 = new WebSocketClient();
//     client2.on('connectFailed', function(error) {
//         console.log('Connect Error: ' + error.toString());
//     });
//     client2.on('connect', function(connection) {
//         console.log('WebSocket Client Connected');
//         connection.on('error', function(error) {
//             console.log("Connection Error: " + error.toString());
//         });
//         connection.on('close', function() {
//             console.log('chat Connection Closed');
//         });
//         connection.on('message', function(message) {
//             const data = JSON.parse(message.utf8Data)
//             console.log("LocalMessage",data)
//         });
//     });
//     client2.connect("ws://localhost:8080","chat");
// },3*1000)