# Console Project
 5일짜리 콘솔 프로젝트

텍스트 RPG 
2024/12/23 ~ 2024/12/27(총 5일)

게임 개요: 몬스터를 잡고 아이템을 사서 최종보스를 잡는 게임

주요 기능
1.게임 시작, 종료
2.맵 이동및 구현
3.상태 출력
4.NPC설정 및 아이템 구매시 스텟 상승
5.몬스터 조우 및 생성
6.전투 시스템
7.승리 및 패배


게임 흐름
1. 게임 시작할지 화면 출력
2. 플레이어 정보 입력
3. 맵 탐색 및 돈 획득과 아이템 구입
4. 보스 몹 전투
5. 목표 달성시 클리어 화면, 죽을시 사망 화면 출력


사용 데이터 구조

1. List<> : 아이템, 몬스터 목록, NPC등
2. Dictionary<> 아이템 관리

클래스 설계

1. Player:플레이어 상태 관리(이름, 체력, 공격력, 방어력, 현재 x좌표, y좌표, 돈)
2. Item: 아이템(무기, 방어구, 물약)
3. NPC: NPC구현(이름, 상호작용)
4. Monster : 몬스터(이름, 체력, 공격력, 방어력, 현재 x좌표, y좌표, 주는 돈)
5. BattleSystem : 전체적인 전투 처리(플레이어가 공격할때, 몬스터가 공격할 때)
6. GameManager: 게임 흐름 제어
7. Map : 플레이어가 돌아다닐 맵
