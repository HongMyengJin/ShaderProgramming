#version 330

layout(location=0) out vec4 FragColor;

uniform sampler2D u_TexSampler;
in vec2 v_TexPos; // uv ÁÂÇ¥

void main()
{
	FragColor = texture(u_TexSampler, v_TexPos);
}
