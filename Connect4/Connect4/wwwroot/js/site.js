//SignalR
var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.start().catch(e => console.log(e));
//Connect4
class Connect4 {
    constructor() {
        this.time = new Date();
        this.currentTurn = false;
        this.players = {}
    }
}


let elements = {
    game: {
        chat: document.getElementById("chat"),
        turn: document.getElementById("currentTurn"),
        time: document.getElementById("gameTime"),
        leave: document.getElementById("leaveGame")
    }
}

function joinGame() {
    connection.invoke("")
}
function startGame() { }

function saveGame() { }


//Logic
const board = [ //Each index is represented as a column
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
    [ 0, 0, 0, 0, 0, 0 ],
]

function placeToken() { }
function isWinner() { }


document.querySelectorAll(".slot").forEach(slot => {
    slot.addEventListener("click", () => slot.classList.add("blue"));
})
connection.on('PlayerConnect', (message) => {
    console.log(message);
    var messageNode = document.createElement("p");
    messageNode.textContent = message;

    elements.game.chat.appendChild(messageNode);

});
connection.on('PlayerDisconnect', (message) => {
    console.log(message);
});
connection.on('GameAvailable', startGame)