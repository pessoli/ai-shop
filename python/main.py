import cv2
import torch
import json
import os
from ultralytics import YOLO

device = torch.device('cpu')

jsonPath = "C:\\Users\\luk\\Desktop\\ai-pattern\\config.json"

def startAI(data):
    model = YOLO("yolo11n.pt")
    model.to(device)

    cap = cv2.VideoCapture(data['video_path'])

    max_people_detected = 0

    while cap.isOpened():
        ret, frame = cap.read()
        if not ret:
            break

        results = model(frame)
        detections = results[0].boxes

        current_visible_people = []
        for detection in detections:
            x_center, y_center, width, height = detection.xywh[0].tolist()
            class_id = int(detection.cls[0].item())  # 0 = person
            
            if class_id == 0:
                if 0 < x_center - width/2 < frame.shape[1] and 0 < x_center + width/2 < frame.shape[1] and \
                0 < y_center - height/2 < frame.shape[0] and 0 < y_center + height/2 < frame.shape[0]:
                    current_visible_people.append((int(x_center), int(y_center), int(width), int(height)))

                    cv2.rectangle(frame, 
                                (int(x_center - width/2), int(y_center - height/2)),
                                (int(x_center + width/2), int(y_center + height/2)),
                                (255, 0, 0), 2)

        num_people = len(current_visible_people)
        cv2.putText(frame, f'Pessoas visíveis: {num_people}', 
                    (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)

        if num_people > max_people_detected:
            max_people_detected = num_people

        cv2.imshow('Detecção de Pessoas', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

    cap.release()
    cv2.destroyAllWindows()
    data['dudes_visible'] = max_people_detected

    with open(jsonPath, 'w') as f:
        json.dump(data,f)

def createJson():
    if os.path.exists(jsonPath):
        print("config exists")
        with open(jsonPath, 'r') as f:
            data = json.load(f)
            print("data loaded:", data)
            
            startAI(data)
            
    else:
        print("config doenst exists, creating another one")
        data = {
            'video_path': 'rsad',
            'dudes_visible': 0,
            'started_recording': 0,
            'ended_recording': 0
        }
        with open(jsonPath, 'w') as json_file:
            json.dump(data, json_file, indent=4)
            print("new json file created")

    with open(jsonPath, 'w') as json_file:
        json.dump(data, json_file, indent=4)
        print("json file updated")

createJson()





