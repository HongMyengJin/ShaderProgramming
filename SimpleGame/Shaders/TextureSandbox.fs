#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_TexPos;
void main()
{
	FragColor = vec4(v_TexPos, 0, 1);
}
