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
2. db추가: syspDB -> Delivery table(key = num) 학교 서버에 mysql 등록. https://cs.esm.kr/
3. 배달 추가: 주소와 전화번호로 새로운 Order객체를 만들고 db에 insert 그리고 리로드
4. 배달 취소: db에서 삭제할 번호로 튜플을 찾아 삭제 그리고 리로드
5. 배달 검색: db에서 해당 전화번호로 검색 후 검색 결과를 출력.
