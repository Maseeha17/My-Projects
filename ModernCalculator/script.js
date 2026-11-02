const currentDisplay = document.getElementById("current");
const previousDisplay = document.getElementById("previous");

let currentNumber = "0";
let previousNumber = null;
let operator = null;
let shouldReset = false;

function updateDisplay() {
    currentDisplay.textContent = currentNumber;
}

function addNumber(number) {
    if (currentNumber === "Error") clearCalculator();

    if (shouldReset) {
        currentNumber = number;
        shouldReset = false;
    } else {
        currentNumber = currentNumber === "0"
            ? number
            : currentNumber + number;
    }

    updateDisplay();
}

function addDecimal() {
    if (currentNumber === "Error") clearCalculator();

    if (shouldReset) {
        currentNumber = "0";
        shouldReset = false;
    }

    if (!currentNumber.includes(".")) {
        currentNumber += ".";
    }

    updateDisplay();
}

function chooseOperator(selectedOperator) {
    if (currentNumber === "Error") return;

    if (operator !== null && !shouldReset) {
        calculate();
    }

    previousNumber = parseFloat(currentNumber);
    operator = selectedOperator;

    previousDisplay.textContent =
        previousNumber + " " + selectedOperator;

    shouldReset = true;
}

function calculate() {
    if (operator === null || shouldReset) return;

    const secondNumber = parseFloat(currentNumber);
    let result;

    switch (operator) {
        case "+":
            result = previousNumber + secondNumber;
            break;

        case "-":
            result = previousNumber - secondNumber;
            break;

        case "*":
            result = previousNumber * secondNumber;
            break;

        case "/":
            if (secondNumber === 0) {
                currentNumber = "Error";
                previousDisplay.textContent = "Cannot divide by zero";
                operator = null;
                previousNumber = null;
                shouldReset = true;
                updateDisplay();
                return;
            }
            result = previousNumber / secondNumber;
            break;
    }

    currentNumber = String(Number(result.toPrecision(12)));

    previousDisplay.textContent = "";
    operator = null;
    previousNumber = null;
    shouldReset = true;

    updateDisplay();
}

function clearCalculator() {
    currentNumber = "0";
    previousNumber = null;
    operator = null;
    shouldReset = false;

    previousDisplay.textContent = "";
    updateDisplay();
}

function deleteNumber() {
    if (currentNumber === "Error") {
        clearCalculator();
        return;
    }

    if (shouldReset) {
        currentNumber = "0";
        shouldReset = false;
    } else {
        currentNumber = currentNumber.slice(0, -1) || "0";
    }

    updateDisplay();
}

function percentage() {
    if (currentNumber === "Error") return;

    currentNumber = String(parseFloat(currentNumber) / 100);
    shouldReset = true;
    updateDisplay();
}

document.querySelectorAll("[data-number]").forEach(button => {
    button.addEventListener("click", () => {
        addNumber(button.dataset.number);
    });
});

document.querySelectorAll("[data-operator]").forEach(button => {
    button.addEventListener("click", () => {
        chooseOperator(button.dataset.operator);
    });
});

document.querySelectorAll("[data-action]").forEach(button => {
    button.addEventListener("click", () => {

        switch (button.dataset.action) {
            case "clear":
                clearCalculator();
                break;

            case "delete":
                deleteNumber();
                break;

            case "decimal":
                addDecimal();
                break;

            case "percent":
                percentage();
                break;

            case "calculate":
                calculate();
                break;
        }

    });
});

document.addEventListener("keydown", (event) => {

    if (event.key >= "0" && event.key <= "9") {
        addNumber(event.key);
    }

    if (event.key === ".") {
        addDecimal();
    }

    if (["+", "-", "*", "/"].includes(event.key)) {
        chooseOperator(event.key);
    }

    if (event.key === "Enter" || event.key === "=") {
        calculate();
    }

    if (event.key === "Backspace") {
        deleteNumber();
    }

    if (event.key === "Escape") {
        clearCalculator();
    }

    if (event.key === "%") {
        percentage();
    }

});