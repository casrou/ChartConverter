var cloneHeroTable = document.querySelector('#chTable');
var beatSaberTable = document.querySelector('#bsTable');

let matrices = {
    green: {
        red: Array(3).fill(Array(4).fill(0)),
        blue: Array(3).fill(Array(4).fill(0))
    },
    red: {
        red: Array(3).fill(Array(4).fill(0)),
        blue: Array(3).fill(Array(4).fill(0))
    },
    yellow: {
        red: Array(3).fill(Array(4).fill(0)),
        blue: Array(3).fill(Array(4).fill(0))
    },
    blue: {
        red: Array(3).fill(Array(4).fill(0)),
        blue: Array(3).fill(Array(4).fill(0))
    },
    orange: {
        red: Array(3).fill(Array(4).fill(0)),
        blue: Array(3).fill(Array(4).fill(0))
    }
};

// matrices.green.red[0] = [0,0,0,0];
// matrices.green.red[1] = [2,0,0,0];
// matrices.green.red[2] = [2,0,0,0];
// matrices.green.blue[0] = [0,0,0,0];
// matrices.green.blue[1] = [0,0,0,2];
// matrices.green.blue[2] = [0,0,0,2];

const upArrow = "▲";
const downArrow = "▼";
const leftArrow = "◀";
const rightArrow = "▶";
const leftUpArrow = "◤";
const rightUpArrow = "◥";
const leftDownArrow = "◣";
const rightDownArrow = "◢";

function getNumberFromArrow(bsArrow) {
    let result = -1;
    switch (bsArrow) {
        case upArrow:
            result = 1;
            break;
        case downArrow:
            result = 2;
            break;
        case leftArrow:
            result = 3;
            break;
        case rightArrow:
            result = 4;
            break;
        case leftUpArrow:
            result = 5;
            break;
        case rightUpArrow:
            result = 6;
            break;
        case leftDownArrow:
            result = 7;
            break;
        case rightDownArrow:
            result = 8;
            break;
        default:
            break;
    }
    return result;
}

function getArrowFromNumber(number) {
    result = null;
    switch (number) {
        case 1:
            result = upArrow;
            break;
        case 2:
            result = downArrow;
            break;
        case 3:
            result = leftArrow;
            break;
        case 4:
            result = rightArrow;
            break;
        case 5:
            result = leftUpArrow;
            break;
        case 6:
            result = rightUpArrow;
            break;
        case 7:
            result = leftDownArrow;
            break;
        case 8:
            result = rightDownArrow;
            break;
        default:
            break;
    }
    return result;
}

function matrixEntryFromBsCellId(matrixColor, bsCellId) {
    var bsCell = beatSaberTable.querySelector(bsCellId);

    bsColor = bsCell.className;
    bsArrow = bsCell.textContent;

    if (bsColor === "") return 0;
    if (matrixColor !== bsColor) return 0;
    let result = getNumberFromArrow(bsArrow);
    return result;
}

let current = "green";
async function saveBsAndClear(fretColor) {
    var bsCells = beatSaberTable.querySelectorAll('td');

    // Save
    if (current != null) {
        let saveRedMatrix = [];
        let saveBlueMatrix = [];

        for (let r = 0; r < 3; r++) {
            let redRow = [];
            let blueRow = [];
            for (let c = 0; c < 4; c++) {
                redRow[c] = matrixEntryFromBsCellId("red", "#bsCell" + r + c)
                blueRow[c] = matrixEntryFromBsCellId("blue", "#bsCell" + r + c)
            }
            saveRedMatrix[r] = redRow;
            saveBlueMatrix[r] = blueRow;
        }

        matrices[current]["red"] = saveRedMatrix;
        matrices[current]["blue"] = saveBlueMatrix;

        console.debug(matrices);
    }

    //Clear
    bsCells.forEach(bsC => {
        bsC.classList.remove("red", "blue");
        bsC.textContent = "";
    });

    // Fill
    let fillRedMatrix = matrices[fretColor]["red"];
    let fillBlueMatrix = matrices[fretColor]["blue"];

    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 4; j++) {
            let redEntry = fillRedMatrix[i][j];
            if (redEntry !== 0) {
                let redCell = beatSaberTable.querySelector("#bsCell" + i + j);
                redCell.className = "red";
                redCell.textContent = getArrowFromNumber(redEntry);
            }

            let blueEntry = fillBlueMatrix[i][j];
            if (blueEntry !== 0) {
                let blueCell = beatSaberTable.querySelector("#bsCell" + i + j);
                blueCell.className = "blue";
                blueCell.textContent = getArrowFromNumber(blueEntry);
            }
        }
    }

    current = fretColor;
}

var cloneHeroTds = cloneHeroTable.querySelectorAll('td');
cloneHeroTds.forEach(chTd => {
    chTd.addEventListener('click', async function (e) {
        await saveBsAndClear(chTd.className);
    }, false);
    chTd.addEventListener('mousedown', function (e) { e.preventDefault(); }, false);
});

function handleBsCell(event, bsCell) {
    event.stopPropagation();
    event.preventDefault();

    if (event.type === 'contextmenu') {
        let color = bsCell.className;
        if (!color || color === "") {
            bsCell.className = "red";
        } else if (color === "red") {
            bsCell.className = "blue";
        } else {
            bsCell.className = "";
        }
        return;
    } else {
        let arrow = bsCell.textContent;
        if (!arrow) {
            bsCell.textContent = upArrow;
            return;
        }
        let nextArrow = getArrowFromNumber(getNumberFromArrow(arrow) + 1);
        bsCell.textContent = nextArrow;
    }
}

var beatsaberCells = beatSaberTable.querySelectorAll('td');
beatsaberCells.forEach(bsCell => {
    bsCell.addEventListener('click', async function (e) {
        await handleBsCell(e, bsCell);
    }, false);
    bsCell.addEventListener('contextmenu', async function (e) {
        await handleBsCell(e, bsCell);
    }, false);
    bsCell.addEventListener('mousedown', function (e) { e.preventDefault(); }, false);
});