# People Detection with C# and Python

This project integrates **C#** and **Python** to detect the maximum number of people present in a given environment through video analysis. The workflow involves using **YOLOv4** (You Only Look Once, version 4) for object detection and a simple **C#** interface to interact with the user and store results in a **PostgreSQL** database.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Workflow](#workflow)
- [Features](#features)
- [Technologies Used](#technologies-used)

---

## Project Overview

This project allows the detection of people in video files using **YOLO11** object detection. The workflow is as follows:

1. **C# Interface**: The user selects video files to analyze. These files are then sent to a **Python** script for processing.
2. **Python Processing**: The Python script uses **YOLO11** to detect the max ammount of people in the video frames and stores the count in a **`config.json`** file.
3. **C# Updates**: The C# application reads the `config.json` file, retrieves the detected people count, and inserts the data (file name, people count, date, and location) into a **PostgreSQL** database.

---

## Workflow

1. **User selects video files**: The C# application allows users to select one or more video files for processing.
2. **File transfer to Python**: The selected files are sent to the Python script for object detection.
3. **People Detection**: The Python script processes each video, using **YOLO11** to detect and count the max people present.
4. **Store Results**: The max number of detected people, along with the video file name, is stored in a **`config.json`** file.
5. **C# Inserts Data into Database**: The C# application reads the results from the JSON file and inserts the data into a **PostgreSQL** database.

---

## Features

- **Real-time Object Detection**: YOLO11 is used to detect people in the video with high accuracy.
- **Cross-Language Integration**: The project uses **C#** for the user interface and database interaction, and **Python** for video processing with YOLO11.
- **Database Storage**: Detection results are stored in a **PostgreSQL** database.
- **JSON Storage**: Intermediate data (such as the number of people detected) is stored in a `config.json` file for debugging and data analysis.

---

## Technologies Used

- **C#**: For the user interface, file selection, and database interaction.
- **Python**: For processing the video files and using YOLOv4 for object detection.
- **YOLO11**: A state-of-the-art real-time object detection model used to detect people in the videos.
- **PostgreSQL**: A relational database used for storing the detection results.
- **JSON**: Used for storing intermediate data, such as the number of people detected in the video.

##Showcase

![image](https://github.com/user-attachments/assets/9189f596-552a-43d5-8833-9f6a1cd43311)

![image](https://github.com/user-attachments/assets/65b5dcfa-15c6-4a85-8700-9876a9dcfa58)

![image](https://github.com/user-attachments/assets/2beb72f8-a25d-4af4-8ea0-2c5a63d4d803)

![image](https://github.com/user-attachments/assets/48b062f1-ff34-4a02-b5f7-f70e37b35d84)

<h1>Vídeo de demonstração</h1>
https://www.youtube.com/watch?v=VXtz6mzxMbw




