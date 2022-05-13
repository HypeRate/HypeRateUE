# Unofficial HypeRate Unreal Engine Plugin
## in Development
### Do not use!
This Plugin is currently only working with a local proxy websocket due to naming issues between UE and openssl.

The provided proxy Server should work. You just need to update the `config.example.js` to `config.js` with needed information.

For more information visit [https://www.hyperate.io/](https://www.hyperate.io/) or their [Discord](https://discord.gg/75jcqvuHAH)

## Known issues
- wss not working due to naming issues between openssl and unreal engine
- Server not disconnecting after stopping the game
- Server not reconnecting after failed attempt/connection lost