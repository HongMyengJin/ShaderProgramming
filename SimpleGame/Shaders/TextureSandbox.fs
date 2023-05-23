#version 330

layout(location=0) out vec4 FragColor;

uniform sampler2D u_TexSampler;
in vec2 v_TexPos; // uv ÁÂÇ¥

void main()
{
	float x = v_TexPos.x;
	float y = 1.0 - abs(v_TexPos.y * 2.f - 1.0);
	vec2 newTexPos = vec2(x, y);
	FragColor = texture(u_TexSampler, newTexPos);
}
