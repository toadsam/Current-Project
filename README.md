# Current-Project

현아/재훈 RPG 프로젝트 연습 저장소입니다. Unity 기반 3D RPG 프로토타입으로, 플레이어 상태 머신, 카메라 처리, 오브젝트 상호작용, 몬스터/환경 에셋을 조합해 액션 RPG의 기본 구조를 실험합니다.

## 프로젝트 개요

이 프로젝트는 완성된 상용 게임보다 RPG 시스템을 직접 구현하고 검증하는 데 초점을 둔 학습형 Unity 프로젝트입니다. 플레이어 이동과 점프, 상태 전환, 상호작용, 카메라 처리 같은 게임의 기반 기능을 C# 스크립트로 나누어 구성했습니다.

## 주요 구현 영역

- 플레이어 상태 머신 기반 이동 처리
- Idle, Walk, Run, Jump, Fall 등 상태별 동작 분리
- ScriptableObject를 활용한 플레이어/상태 데이터 관리
- 레이캐스트 기반 상호작용 처리
- 카메라 전환과 시야 방해 오브젝트 투명화
- DOTween, Cinemachine, Input System 기반 Unity 기능 실험

## 기술 스택

- Unity `2022.3.2f1`
- C#
- Universal Render Pipeline
- Unity Input System
- Cinemachine
- DOTween / DOTween Pro
- Post Processing

## 폴더 구조

```text
.
├── Assets/
│   ├── Scripts/
│   │   ├── Characters/
│   │   ├── Camera/
│   │   └── Button/
│   ├── ScripableObjects/
│   ├── InputActions/
│   └── Scenes/
├── Packages/
└── ProjectSettings/
```

## 실행 방법

1. Unity Hub에서 `2022.3.2f1` 버전을 설치합니다.
2. Unity Hub에서 이 저장소 루트 폴더를 프로젝트로 엽니다.
3. 패키지 복원이 완료될 때까지 기다립니다.
4. `Assets/Scenes` 아래의 씬을 열고 Play 버튼으로 실행합니다.

## 개발 메모

이 저장소는 RPG 전투와 탐색 시스템을 작은 단위로 검증하기 위한 연습 프로젝트입니다. 이후에는 시작 씬, 조작법, 구현된 전투 루프, 빌드 파일 링크를 README에 추가하면 프로젝트 설명력이 더 좋아집니다.
