// Write a program to read a sequence of integers and find and print the top 5
// numbers greater than the average value in the sequence, sorted in descending
// order.
function solve(str) {
    const nums = str.split(' ').map(n => +n);
    const avg = nums.reduce((sum, n) => sum + n) / nums.length;
    const filteredNums = nums.filter(n => n > avg);

    if (filteredNums.length === 0) {
        console.log('No');
        return;
    }

    const orderedNums = filteredNums.sort((a, b) => b - a);
    const top5 = orderedNums.slice(0, 5);
    console.log(top5.join(' '));
}

function solve2(str) {
    const nums = str.split(' ').map(n => +n);

    // Sum
    let sum = 0;
    for (let n of nums) {
        sum += n;
    }

    // Average
    const avg = sum / nums.length;

    // Filter
    let index = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] > avg) {
            nums[index] = nums[i]; 
            index++;
        }
    }
    nums.length = index;

    if (nums.length === 0) {
        console.log('No');
        return;
    }

    // Bubble Sort
    for (let i = 0; i < nums.length - 1; i++) {
        let swapped = false;

        for (let j = 0; j < nums.length - 1 - i; j++) {
            if (nums[j] < nums[j + 1]) {
                const temp = nums[j];
                nums[j] = nums[j + 1];
                nums[j + 1] = temp;
                swapped = true;
            }
        }

        if (!swapped) {
            break;
        }
    }

    // Top 5
    if (nums.length > 5) {
        nums.length = 5;
    }

    let output = "";
    for (let i = 0; i < nums.length; i++) {
        if (i !== nums.length - 1) {
            output += `${nums[i]} `;
        } else {
            output += nums[i];
        }
    }

    console.log(output);
}

let nums = [1, 2, 5, 4, 3, 6, 7];

// Cycle through all the elements. Each pass guarantees that the largest
// unsorted element is set to its correct position.
for (let i = 0; i < nums.length - 1; i++) {
    let swapped = false;

    // Compare each pair of adjacent elements until the last sorted element.
    for (let j = 0; j < nums.length - 1 - i; j++) {
        if (nums[j] > nums[j + 1]) {
            let temp = nums[j];
            nums[j] = nums[j + 1];
            nums[j + 1] = temp;
            swapped = true;
        }
    }

    // If no swaps were made the array is already ordered.
    if (!swapped) {
        break;
    }
}