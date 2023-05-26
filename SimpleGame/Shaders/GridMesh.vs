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
	float y = a_Position.y + temp * 0.5 * sin((value + u_Time)); // �÷� ���� ����: sin((value + u_Time))
	vec4 new_Position = vec4(x, y, 0.0, 1.0);
	gl_Position = new_Position;
	float tx = a_Position.x + 0.5;
	float ty = a_Position.y * (-1) + 0.5f;
	v_TexPos = vec2(tx, ty);
	v_greyScale = sin((value + u_Time));
}


void main()
{
	Test();
}