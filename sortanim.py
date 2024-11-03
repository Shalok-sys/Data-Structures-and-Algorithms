import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Merge function that merges two halves
def merge(arr, left, mid, right, lines):
    n1 = mid - left + 1
    n2 = right - mid
    L = arr[left:mid + 1]
    R = arr[mid + 1:right + 1]

    i = 0  # Initial index of first subarray
    j = 0  # Initial index of second subarray
    k = left  # Initial index of merged subarray

    # Merge the temp arrays back into arr[left:right+1]
    while i < n1 and j < n2:
        if L[i] <= R[j]:
            arr[k] = L[i]
            i += 1
        else:
            arr[k] = R[j]
            j += 1
        lines.append(arr.copy())  # Record state for animation
        k += 1

    # Copy the remaining elements of L[], if there are any
    while i < n1:
        arr[k] = L[i]
        i += 1
        k += 1
        lines.append(arr.copy())

    # Copy the remaining elements of R[], if there are any
    while j < n2:
        arr[k] = R[j]
        j += 1
        k += 1
        lines.append(arr.copy())

# Merge sort function
def merge_sort(arr, left, right, lines):
    if left < right:
        mid = (left + right) // 2
        merge_sort(arr, left, mid, lines)
        merge_sort(arr, mid + 1, right, lines)
        merge(arr, left, mid, right, lines)

# Function to animate merge sort
def animate_merge_sort(arr):
    lines = []
    merge_sort(arr, 0, len(arr) - 1, lines)
    
    fig, ax = plt.subplots()
    ax.set_title('Merge Sort Animation')
    bar_rects = ax.bar(range(len(arr)), arr, color='lightblue')
    ax.set_ylim(0, max(arr) + 2)  # Set the y-limit with extra space
    ax.set_yticks(np.arange(0, max(arr) + 2, 2))  # Set y-ticks at intervals of 2

    def update(frame):
        for rect, val in zip(bar_rects, lines[frame]):
            rect.set_height(val)
        return bar_rects

    ani = FuncAnimation(fig, update, frames=len(lines), repeat=False, blit=True)
    plt.show()

# Example usage
if __name__ == "__main__":
    data = [1,3,10,8,12,23,6, 18, 12, 22, 9]
    print("Initial Array:", data)
    animate_merge_sort(data)
