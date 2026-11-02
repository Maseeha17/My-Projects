// ========================================
// AURA - COLOUR PALETTE STUDIO
// ========================================


// ========================================
// ELEMENTS
// ========================================

const palette = document.getElementById("palette");

const generateBtn = document.getElementById("generateBtn");
const saveBtn = document.getElementById("saveBtn");

const colourCards = document.querySelectorAll(".colour-card");
const lockButtons = document.querySelectorAll(".colour-lock");
const themeButtons = document.querySelectorAll(".theme-btn");

const favouritesGrid = document.getElementById("favouritesGrid");
const favouriteCount = document.getElementById("favouriteCount");


// ========================================
// COLOUR DATA
// ========================================

let colours = [
    "#E8A598",
    "#D8B4A0",
    "#A8B5A2",
    "#7D8F83",
    "#454F46"
];

let lockedColours = [false, false, false, false, false];

let currentTheme = "random";


// ========================================
// THEME PALETTES
// ========================================

const themes = {

    pastel: [
        ["#F7C8D0", "#FCE1B6", "#D5E8D4", "#C8D8F0", "#E5D4F0"],
        ["#FFD6E0", "#FFF0C9", "#CDEAC0", "#C5DFF8", "#E8D5F5"]
    ],

    earthy: [
        ["#A98467", "#DDB892", "#E6CCB2", "#7F5539", "#6F4E37"],
        ["#606C38", "#283618", "#DDA15E", "#BC6C25", "#FEFAE0"]
    ],

    luxury: [
        ["#1B1B1B", "#C9A227", "#F5F0E6", "#6B2737", "#343434"],
        ["#14213D", "#D4AF37", "#FCA311", "#E5E5E5", "#000000"]
    ],

    vibrant: [
        ["#FF595E", "#FFCA3A", "#8AC926", "#1982C4", "#6A4C93"],
        ["#F72585", "#7209B7", "#3A0CA3", "#4361EE", "#4CC9F0"]
    ]

};


// ========================================
// GENERATE RANDOM COLOUR
// ========================================

function randomColour() {

    return "#" + Math.floor(Math.random() * 16777215)
        .toString(16)
        .padStart(6, "0")
        .toUpperCase();

}


// ========================================
// DISPLAY CURRENT PALETTE
// ========================================

function displayPalette() {

    colourCards.forEach((card, index) => {

        const preview = card.querySelector(".colour-preview");
        const colourCode = card.querySelector("strong");

        preview.style.backgroundColor = colours[index];

        colourCode.textContent = colours[index];

        card.classList.toggle("locked", lockedColours[index]);

        lockButtons[index].textContent =
            lockedColours[index] ? "🔒" : "🔓";

    });

}


// ========================================
// GENERATE NEW PALETTE
// ========================================

function generatePalette() {

    let selectedPalette = null;

    if (currentTheme !== "random") {

        const themeOptions = themes[currentTheme];

        selectedPalette = themeOptions[
            Math.floor(Math.random() * themeOptions.length)
        ];

    }

    colours = colours.map((colour, index) => {

        if (lockedColours[index]) {
            return colour;
        }

        if (selectedPalette) {
            return selectedPalette[index];
        }

        return randomColour();

    });

    displayPalette();

}


// ========================================
// GENERATE BUTTON
// ========================================

generateBtn.addEventListener("click", () => {

    currentTheme = "random";

    generatePalette();

});


// ========================================
// INDIVIDUAL COLOUR LOCKING
// ========================================

lockButtons.forEach((button, index) => {

    button.addEventListener("click", () => {

        lockedColours[index] = !lockedColours[index];

        displayPalette();

    });

});


// ========================================
// THEME BUTTONS
// ========================================

themeButtons.forEach(button => {

    button.addEventListener("click", () => {

        currentTheme = button.dataset.theme;

        generatePalette();

    });

});


// ========================================
// COPY HEX COLOUR CODE
// ========================================

colourCards.forEach(card => {

    const colourCode = card.querySelector("strong");

    colourCode.style.cursor = "pointer";

    colourCode.addEventListener("click", async () => {

        try {

            await navigator.clipboard.writeText(colourCode.textContent);

            const originalText = colourCode.textContent;

            colourCode.textContent = "COPIED!";

            setTimeout(() => {

                colourCode.textContent = originalText;

            }, 1000);

        } catch (error) {

            alert("Unable to copy colour code.");

        }

    });

});


// ========================================
// GET SAVED PALETTES
// ========================================

function getSavedPalettes() {

    return JSON.parse(localStorage.getItem("auraPalettes")) || [];

}


// ========================================
// SAVE FAVOURITE PALETTE
// ========================================

saveBtn.addEventListener("click", () => {

    const savedPalettes = getSavedPalettes();

    const paletteExists = savedPalettes.some(savedPalette =>
        JSON.stringify(savedPalette) === JSON.stringify(colours)
    );

    if (paletteExists) {

        alert("This palette is already saved!");

        return;

    }

    savedPalettes.push([...colours]);

    localStorage.setItem(
        "auraPalettes",
        JSON.stringify(savedPalettes)
    );

    displayFavourites();

    alert("Your palette has been saved! ♡");

});


// ========================================
// DISPLAY FAVOURITE PALETTES
// ========================================

function displayFavourites() {

    const savedPalettes = getSavedPalettes();

    favouritesGrid.innerHTML = "";

    favouriteCount.textContent =
        savedPalettes.length + " SAVED";


    if (savedPalettes.length === 0) {

        favouritesGrid.innerHTML = `
            <p class="empty-message">
                Your favourite palettes will appear here.
            </p>
        `;

        return;

    }


    savedPalettes.forEach((savedPalette, index) => {

        const favouriteCard = document.createElement("div");

        favouriteCard.className = "favourite-card";


        const colourPreview = savedPalette.map(colour => {

            return `<div style="background-color: ${colour};"></div>`;

        }).join("");


        favouriteCard.innerHTML = `

            <div class="favourite-colours">
                ${colourPreview}
            </div>

            <div class="favourite-actions">

                <button class="use-palette" data-index="${index}">
                    Use Palette
                </button>

                <button class="delete-palette" data-index="${index}">
                    Delete
                </button>

            </div>

        `;


        favouritesGrid.appendChild(favouriteCard);

    });

}


// ========================================
// FAVOURITE PALETTE BUTTONS
// ========================================

favouritesGrid.addEventListener("click", event => {

    const index = Number(event.target.dataset.index);

    if (event.target.classList.contains("use-palette")) {

        const savedPalettes = getSavedPalettes();

        colours = [...savedPalettes[index]];

        currentTheme = "random";

        displayPalette();

        window.scrollTo({
            top: 0,
            behavior: "smooth"
        });

    }


    if (event.target.classList.contains("delete-palette")) {

        const savedPalettes = getSavedPalettes();

        const confirmed = confirm(
            "Are you sure you want to delete this palette?"
        );

        if (!confirmed) {
            return;
        }

        savedPalettes.splice(index, 1);

        localStorage.setItem(
            "auraPalettes",
            JSON.stringify(savedPalettes)
        );

        displayFavourites();

    }

});


// ========================================
// INITIAL DISPLAY
// ========================================

displayPalette();

displayFavourites();

// ========================================
// AURA GRADIENT GENERATOR
// ========================================

const gradientPreview = document.getElementById("gradientPreview");

const gradientColour1 = document.getElementById("gradientColour1");

const gradientColour2 = document.getElementById("gradientColour2");

const gradientType = document.getElementById("gradientType");

const gradientDirection = document.getElementById("gradientDirection");

const randomGradientBtn = document.getElementById("randomGradientBtn");

const copyGradientBtn = document.getElementById("copyGradientBtn");

const gradientMessage = document.getElementById("gradientMessage");


// UPDATE GRADIENT

function updateGradient() {

    const colour1 = gradientColour1.value;

    const colour2 = gradientColour2.value;

    const type = gradientType.value;

    const direction = gradientDirection.value;

    let gradient;

    if (type === "linear") {

        gradient = `linear-gradient(${direction}, ${colour1}, ${colour2})`;

    } else {

        gradient = `radial-gradient(circle, ${colour1}, ${colour2})`;

    }

    gradientPreview.style.background = gradient;

    return gradient;

}


// UPDATE WHEN COLOURS CHANGE

gradientColour1.addEventListener("input", updateGradient);

gradientColour2.addEventListener("input", updateGradient);


// UPDATE WHEN OPTIONS CHANGE

gradientType.addEventListener("change", updateGradient);

gradientDirection.addEventListener("change", updateGradient);


// RANDOM GRADIENT

randomGradientBtn.addEventListener("click", () => {

    gradientColour1.value = randomColour();

    gradientColour2.value = randomColour();

    updateGradient();

    gradientMessage.textContent = "Your new gradient is ready! ✨";

});


// COPY CSS CODE

copyGradientBtn.addEventListener("click", async () => {

    const gradient = updateGradient();

    try {

        await navigator.clipboard.writeText(
            `background: ${gradient};`
        );

        gradientMessage.textContent = "CSS gradient copied successfully! ♡";

    } catch (error) {

        gradientMessage.textContent = "Unable to copy CSS code.";

    }

});


// INITIAL GRADIENT

updateGradient();