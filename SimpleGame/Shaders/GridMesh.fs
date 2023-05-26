#version 330


layout(location=0) out vec4 FragColor;
uniform sampler2D u_Texture;

in vec2 v_TexPos;
in float v_greyScale;
void main()
{
	vec2 newTexPos = fract(v_TexPos * 16.0);
	FragColor = 0.5 * (v_greyScale + 1.f) * texture(u_Texture, newTexPos);
}