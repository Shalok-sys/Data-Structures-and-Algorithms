import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Function to animate sorting algorithms
def animate_sorting(arr, sort_func, title='Sorting Animation'):
    lines = []
    sort_func(arr, lines)

    fig, ax = plt.subplots()
    ax.set_title(title)
    bar_rects = ax.bar(range(len(arr)), arr, color='lightblue')
    ax.set_ylim(0, max(arr) + 1)

    def update(frame):
        for rect, val in zip(bar_rects, lines[frame]):
            rect.set_height(val)
        return bar_rects

    ani = FuncAnimation(fig, update, frames=len(lines), repeat=False, blit=True)
    plt.show()

# Example sorting algorithm: Bubble Sort
def bubble_sort(arr, lines):
    n = len(arr)
    for i in range(n):
        for j in range(0, n-i-1):
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
            lines.append(arr.copy())  # Record state for animation

# Example sorting algorithm: Selection Sort
def selection_sort(arr, lines):
    n = len(arr)
    for i in range(n):
        min_idx = i
        for j in range(i+1, n):
            if arr[j] < arr[min_idx]:
                min_idx = j
        arr[i], arr[min_idx] = arr[min_idx], arr[i]
        lines.append(arr.copy())  # Record state for animation

# Example sorting algorithm: Insertion Sort
def insertion_sort(arr, lines):
    for i in range(1, len(arr)):
        key = arr[i]
        j = i - 1
        while j >= 0 and key < arr[j]:
            arr[j + 1] = arr[j]
            j -= 1
        arr[j + 1] = key
        lines.append(arr.copy())  # Record state for animation

# Example usage
if __name__ == "__main__":
    data = [1,3,10,8,12,23,6, 18, 12, 22, 9]
    print("Initial Array:", data)

    # Choose a sorting algorithm to visualize
    animate_sorting(data.copy(), bubble_sort, title='Bubble Sort Animation')
    # animate_sorting(data.copy(), selection_sort, title='Selection Sort Animation')
    # animate_sorting(data.copy(), insertion_sort, title='Insertion Sort Animation')
