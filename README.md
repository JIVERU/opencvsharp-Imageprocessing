# RevaldeImageProcessing
![Screenshot](Assets/Screenshot%202025-09-24%20030734.png)
## Overview

This project is an **image processing activity** built using the [OpenCvSharp](https://github.com/shimat/opencvsharp) wrapper for the OpenCV library. It provides a simple Windows Forms interface for performing basic image manipulations. The application is a required deliverable for the **Intelligent Systems 1 (CS345)** course.

## Features

- **Image Upload:** Load images in common formats (`.jpg`, `.jpeg`, `.png`, `.bmp`).
- **Image Display:** View the original and processed images side-by-side.
- **Image Operations:**
  - Copy
  - Greyscale conversion
  - Color inversion
  - Sepia filter
  - Histogram
- **Video dynamic processing using subtraction**
- **Save Processed Image:** Export the modified image to disk.

## Technologies

- **C# 12.0**
- **.NET 8**
- **OpenCvSharp** (OpenCV wrapper for .NET)
- **Windows Forms**

## How to Run

1. **Clone or download** the repository.
2. **Open the solution** in Visual Studio 2022 or later.
3. **Restore NuGet packages** (OpenCvSharp).
4. **Build and run** the project.
5. Use the UI to upload an image, select an operation from the combo box or menu, and view/save the result.

## Usage

- **Upload Image:** Click the upload button or use the menu to select an image file.
- **Select Operation:** Choose an image operation from the combo box or menu.
- **Run:** Click the run button to process the image.
- **Save:** Use the save button or menu to export the processed image.

## Notes

- Some features (histogram, RGB histogram) are placeholders and may require further implementation.
- The application handles common image channel formats and prevents errors due to channel mismatches.

## License

This project is for educational purposes as part of the CS345 course.  
OpenCvSharp is licensed under the MIT License.

## Author

- JIVERU
- Intelligent Systems 1 (CS345)
