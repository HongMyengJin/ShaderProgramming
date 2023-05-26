#version 330

in vec3 a_Position; //ATTRIBUTE (VS INPUT)

const float PI = 3.141592;

uniform float u_Time;

out vec2 v_TexPos;
out float v_greyScale;

void Test()
{
	float x = a_Position.x;
	float temp = a_Position.x + 0.5;
	float value = (a_Position.x + 0.5) * 2.0 * PI;
	float y = a_Position.y + temp * 0.5 * sin((value - u_Time)); // 컬러 음영 조절: sin((value + u_Time))
	vec3 new_Position = vec3(x, y, 0.0);

	vec3 tarPosition = vec3(1.0, 1.0, 0.0);
	float newTime = fract(u_Time) - a_Position.y;
	vec3 morphPosition = mix(new_Position, tarPosition, newTime); // 0.5면 화면 중간
	gl_Position = vec4(morphPosition, 1.0);
	//gl_Position = new_Position;

	float tx = a_Position.x + 0.5;
	float ty = a_Position.y * (-1) + 0.5f;
	v_TexPos = vec2(tx, ty);
	v_greyScale = sin((value + u_Time));
}


void main()
{
	Test();
}