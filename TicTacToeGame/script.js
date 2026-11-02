// ======================================
// TIC TAC TOE GAME
// ======================================

// Game elements
const cells = document.querySelectorAll(".cell");
const gameStatus = document.getElementById("gameStatus");

const scoreXDisplay = document.getElementById("scoreX");
const scoreODisplay = document.getElementById("scoreO");

const playerXDisplay = document.getElementById("playerX");
const playerODisplay = document.getElementById("playerO");

const newGameBtn = document.getElementById("newGameBtn");
const resetBtn = document.getElementById("resetBtn");

// Game variables
let currentPlayer = "X";
let gameBoard = ["", "", "", "", "", "", "", "", ""];
let gameActive = true;

let scoreX = 0;
let scoreO = 0;

// Winning combinations
const winningCombinations = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
];

// ======================================
// HANDLE CELL CLICK
// ======================================

cells.forEach(cell => {
    cell.addEventListener("click", () => {

        const index = Number(cell.dataset.index);

        // Stop if the game has ended or cell is occupied
        if (!gameActive || gameBoard[index] !== "") {
            return;
        }

        // Place player's symbol
        gameBoard[index] = currentPlayer;

        cell.textContent = currentPlayer;
        cell.classList.add(currentPlayer.toLowerCase());
        cell.disabled = true;

        // Check for winner
        checkWinner();

    });
});

// ======================================
// CHECK FOR WINNER
// ======================================

function checkWinner() {

    let winningCombination = null;

    for (const combination of winningCombinations) {

        const [a, b, c] = combination;

        if (
            gameBoard[a] !== "" &&
            gameBoard[a] === gameBoard[b] &&
            gameBoard[a] === gameBoard[c]
        ) {
            winningCombination = combination;
            break;
        }
    }

    // Someone has won
    if (winningCombination) {

        gameActive = false;

        winningCombination.forEach(index => {
            cells[index].classList.add("winner");
        });

        if (currentPlayer === "X") {
            scoreX++;
            scoreXDisplay.textContent = scoreX;
        } else {
            scoreO++;
            scoreODisplay.textContent = scoreO;
        }

        gameStatus.textContent = `🎉 Player ${currentPlayer} wins!`;

        cells.forEach(cell => {
            cell.disabled = true;
        });

        return;
    }

    // Check for draw
    if (!gameBoard.includes("")) {

        gameActive = false;
        gameStatus.textContent = "It's a draw! 🤝";

        return;
    }

    // Switch player
    currentPlayer = currentPlayer === "X" ? "O" : "X";

    updateTurn();
}

// ======================================
// UPDATE CURRENT PLAYER
// ======================================

function updateTurn() {

    gameStatus.textContent = `Player ${currentPlayer}'s turn`;

    playerXDisplay.classList.toggle(
        "active",
        currentPlayer === "X"
    );

    playerODisplay.classList.toggle(
        "active",
        currentPlayer === "O"
    );
}

// ======================================
// START NEW GAME
// ======================================

function newGame() {

    gameBoard = ["", "", "", "", "", "", "", "", ""];

    currentPlayer = "X";
    gameActive = true;

    cells.forEach(cell => {

        cell.textContent = "";
        cell.disabled = false;

        cell.classList.remove(
            "x",
            "o",
            "winner"
        );

    });

    updateTurn();
}

// ======================================
// RESET SCORES
// ======================================

function resetScores() {

    scoreX = 0;
    scoreO = 0;

    scoreXDisplay.textContent = "0";
    scoreODisplay.textContent = "0";

    newGame();
}

// ======================================
// BUTTON EVENTS
// ======================================

newGameBtn.addEventListener("click", newGame);

resetBtn.addEventListener("click", resetScores);

// ======================================
// START GAME
// ======================================

updateTurn();