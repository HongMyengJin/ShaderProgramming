#version 330

layout(location=0) out vec4 FragColor;
layout(location=1) out vec4 FragColor1;
layout(location=2) out vec4 FragColor2;
layout(location=3) out vec4 FragColor3;
varying vec4 v_Color;
in vec2 v_UV;

uniform sampler2D u_Texture;

void circle()
{
	vec2 temp = v_UV - vec2(0.5, 0.5);
	float d = length(temp);
	if(d<0.5)
	{
		FragColor = vec4(1)*v_Color;
	}
	else
	{
		FragColor = vec4(0);
	}
}

void circles()
{
	vec2 temp = v_UV - vec2(0.5, 0.5);
	float d = length(temp); 
	float value = sin(30*d);

	FragColor = vec4(value)*v_Color;
}

void Textured()
{
	vec4 result = texture(u_Texture, v_UV) * v_Color;
	FragColor = result;
}
void main()
{
	//FragColor = v_Color;
	circles();
	//Textured();
	FragColor1 = vec4(1, 0, 0, 1);
	FragColor2 = vec4(0, 1, 0, 1);
	FragColor3 = vec4(0, 0, 1, 1);

}
