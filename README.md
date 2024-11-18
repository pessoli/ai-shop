# People Detection with C# and Python

🇺🇸 [English Version](#people-detection-with-c-and-python) | 🇧🇷 [Versão em Português](#traduzido)

## People Detection with C# and Python

This project integrates **C#** and **Python** to detect the maximum number of people present in a given environment through video analysis. The workflow involves using **YOLO11** (You Only Look Once, version 11) for object detection and a simple **C#** interface to interact with the user and store results in a **PostgreSQL** database.

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

<h1>Showcase video</h1>
https://www.youtube.com/watch?v=VXtz6mzxMbw
<br><br><br><br><br><br>



## Traduzido

Este projeto integra **C#** e **Python** para detectar o número máximo de pessoas presentes em um ambiente através da análise de vídeos. O fluxo de trabalho envolve o uso do **YOLO11** (You Only Look Once, versão 11) para detecção de objetos e uma interface simples em **C#** para interagir com o usuário e armazenar os resultados em um banco de dados **PostgreSQL**.

---

## Índice

- [Visão Geral do Projeto](#visão-geral-do-projeto)
- [Fluxo de Trabalho](#fluxo-de-trabalho)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Demonstração](#demonstração)

---

## Visão Geral do Projeto

Este projeto permite a detecção de pessoas em arquivos de vídeo utilizando a detecção de objetos com **YOLO11**. O fluxo de trabalho é o seguinte:

1. **Interface C#**: O usuário seleciona os arquivos de vídeo para análise. Esses arquivos são enviados para um script **Python** para processamento.
2. **Processamento em Python**: O script Python utiliza o **YOLO11** para detectar o número máximo de pessoas nos quadros do vídeo e armazena a contagem em um arquivo **`config.json`**.
3. **Atualizações em C#**: O aplicativo C# lê o arquivo `config.json`, recupera a quantidade de pessoas detectadas e insere os dados (nome do arquivo, quantidade de pessoas, data e local) em um banco de dados **PostgreSQL**.

---

## Fluxo de Trabalho

1. **Usuário seleciona os arquivos de vídeo**: O aplicativo C# permite que o usuário selecione um ou mais arquivos de vídeo para processamento.
2. **Transferência dos arquivos para o Python**: Os arquivos selecionados são enviados para o script Python para detecção de objetos.
3. **Detecção de Pessoas**: O script Python processa cada vídeo, utilizando o **YOLO11** para detectar e contar o número máximo de pessoas presentes.
4. **Armazenamento dos Resultados**: O número máximo de pessoas detectadas, juntamente com o nome do arquivo de vídeo, é armazenado em um arquivo **`config.json`**.
5. **C# Insere os Dados no Banco de Dados**: O aplicativo C# lê os resultados do arquivo JSON e insere os dados em um banco de dados **PostgreSQL**.

---

## Funcionalidades

- **Detecção de Objetos em Tempo Real**: O **YOLO11** é utilizado para detectar pessoas no vídeo com alta precisão.
- **Integração entre Linguagens**: O projeto usa **C#** para a interface com o usuário e interação com o banco de dados, e **Python** para o processamento de vídeos com o **YOLO11**.
- **Armazenamento em Banco de Dados**: Os resultados da detecção são armazenados em um banco de dados **PostgreSQL**.
- **Armazenamento em JSON**: Dados intermediários (como o número de pessoas detectadas) são armazenados em um arquivo `config.json` para análise e depuração.

---

## Tecnologias Utilizadas

- **C#**: Para a interface com o usuário, seleção de arquivos e interação com o banco de dados.
- **Python**: Para processar os arquivos de vídeo e utilizar o **YOLO11** para a detecção de objetos.
- **YOLO11**: Um modelo de detecção de objetos em tempo real utilizado para detectar pessoas nos vídeos.
- **PostgreSQL**: Um banco de dados relacional utilizado para armazenar os resultados da detecção.
- **JSON**: Utilizado para armazenar dados intermediários, como o número de pessoas detectadas no vídeo.

---

## Demonstração

![image](https://github.com/user-attachments/assets/9189f596-552a-43d5-8833-9f6a1cd43311)

![image](https://github.com/user-attachments/assets/65b5dcfa-15c6-4a85-8700-9876a9dcfa58)

![image](https://github.com/user-attachments/assets/2beb72f8-a25d-4af4-8ea0-2c5a63d4d803)

![image](https://github.com/user-attachments/assets/48b062f1-ff34-4a02-b5f7-f70e37b35d84)


<h1> Vídeo de Demonstração de Detecção de Pessoas</h1>

https://www.youtube.com/watch?v=VXtz6mzxMbw)
