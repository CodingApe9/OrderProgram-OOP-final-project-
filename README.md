https://github.com/hansei-it/telphoneapp_cs21

# 원본 소스

1. 첫 프로젝트 실습 시작

2. 기본 Person 객체 생성과 People객체 생성 및 
추가 버튼 UI 작성

3. Person 클래스와 People 클래스를 파일로 모듈화하고 추가버튼 클릭 시 텍스트박스의 내용을 비우고 포커스를 지정함.

4. 검색, 삭제 버튼 UI 작성

5. 검색 버튼의 이벤트 생성 및 검색 기능 구현

6. 검색, 삭제 기능 구현 및 출력 버튼 이벤트 구현
---

추가한 기능.

1. 프로그램 목적 변경 그에 따른 디자인 변경: 전화 프로그램 -> 가게에서 배달 기사를 호출하는 프로그램으로 용도 변경
    변경 전.
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/30e8a275-3043-4a9d-bf02-93b7bd630610)
    
    변경 후.
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/e65beefe-70f6-44a3-9aa3-88e7c61bee59)

2. db추가: syspDB 학과 DB서버에 mysql 등록. https://cs.esm.kr/
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/c5a5b6e4-c491-4527-a8fd-09f5fb8701f9)
    ![tempsnip](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/62ab5c82-d980-496b-a588-e53dbfcd32f8)

3. 배달 추가: 주소와 전화번호로 새로운 Order객체를 만들고 db에 insert 그리고 리로드
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/ab43931a-1326-4499-a8f8-f401c0a326be)
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/70501509-56a5-4751-b7d4-7de3b15c5432)

4. 배달 취소: db에서 삭제할 번호로 튜플을 찾아 삭제 그리고 리로드
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/3b8af975-1a60-4373-a209-427b833f097c)
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/d1e269e5-1a8d-4d2c-a13b-94b1b996626e)
    
5. 배달 검색: db에서 해당 전화번호로 검색 후 검색 결과를 출력.
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/a84740cf-b009-4e3b-b0e1-7cbe082b4e70)
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/7bd686e4-f2cf-4b9a-9d6e-5f98de893b97)
    
6. 배달 자동 추가: 
    이용 시나리오:
      1. 배민에서 주문이 들어옴.
      2. BaeminDB에 주문이 저장됨.
      3. 주문 자동 추가를 누르면 배민DB에서 주문 정보를 가져옴.
      4. 자동으로 배달 목록에 추가 시킴. (3번의 배달 추가)
    
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/2629c16c-da60-4c5c-a06a-baf5cbcae5a9)
    ![image](https://github.com/CodingApe9/OrderProgram-OOP-final-project-/assets/117576404/e5594551-bcc2-4903-a3af-64d80d61d371)

    
7. 기사 호출: 회사를 선택하고 기사를 호출한다. 배달 예정시간과 회사, 상태를 바꾸고 데이터를 db에 저장.
8. 배달 대행 업체 표시: 최근에 어떤 배달 대행 업체를 불렀는지 기사를 호출 후 그에 해당하는 로고를 좌상단에 표시.
9. 전체 현황: 모든 배달을 출력한다.
10. 통계: 회사별 배달 횟수를 출력한다.
11. 시전 전: 기사를 호출했으나 아직 배달을 시작하기 전 상태 인 배달들을 보여줌.
12. 시작 후: 진행중인 배달들을 보여줌.
13. 완료: 완료한 배달들을 보여줌.
14. 메가커피 웹 사이트 띄우기: 메가커피 사진을 클릭하면 메가커피 웹 사이트 창을 띄운다.
15. 저장 후 프로그램 종료: 프로그램을 종료한다. 프로그램 실행 도중 DB에 저장되지 않은 정보가 있을 수도 있으니 모든 데이터를 DB에 저장하고 종료한다.
