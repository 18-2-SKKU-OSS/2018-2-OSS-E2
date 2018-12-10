LightSystem_samplescenePKG에 대한 README입니다.

[Play]
1. 화면의 버튼을 누르면 각 색상에 알맞은 조명을 조정할 수 있습니다.

[How to Use]
1. 사용하실 광원에는 'Switch Light' 컴포넌트를 적용하세요.
2. 1.에서 지정한 광원을 조정할 스위치에는 'isClick' 컴포넌트를 적용하세요.
3. 빈 게임오브젝트에 'Light System' 컴포넌트를 적용한 후, 1.과 2.에서 사용할 것을 필드에 추가해주세요.
*주의* 3.에 과정에서 연결될 광원과 조정 스위치는 같은 인덱스여야합니다.

[Advice]
1. 'Switch Light' 컴포넌트에서 광원의 시작 상태를 설정할 수 있습니다. (필드 isTurnOnStart)
2. 'Light System' 컴포넌트에서 lights와 switches 필드의 크기는 같아야 정상적으로 작동합니다.
3. 스위치를 작동시키기 위해선 스위치에 입력이 들어왔을 시에 'isClick' 컴포넌트의 'isClicked()' 함수를 실행시켜야 스위치의 작동이 정상적으로 이루어집니다.
