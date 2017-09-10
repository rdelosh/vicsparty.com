# vicsparty.com
Description of the Project:

VicsParty is a small project that I have written over the past week. Essentially VicsParty is a multiplayer game where each person is competing against each other to see who is going to finish typing first. The project uses c# and asp.net on the server side and plain old javascript and jquery on the client. The communication is done over websockets and everytime a player performs an action that needs to be notified to the other player a websocket request is sent in the form of json to the server, the server validates the request and sends its confirmation to everybody who is connected to the specified room.

Future work and vision of the project:

There are still many bugs left in this project, I plan to revisit the project when I get some time next month. Initially I had planned to make VicsParty a platform for multiple simple multiplayer games, but given the time it takes to build the client for one specific game made me look for an alternative on how to code these game clients in a more modular way. I have just started learning React and Redux I believe the modularity of this library will help a lot in the long run when it comes to this project and I plan to use this library when I revisit the project in the future.
