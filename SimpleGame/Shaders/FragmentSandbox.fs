#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_Texcoord;

uniform vec2 u_Point;
uniform vec2 u_Points[3];
uniform float u_Time;
const float c_PI = 3.141592;

void test()
{
	float newValueX = v_Texcoord.x * 10.0 * c_PI;
	float newValueY = v_Texcoord.y * 10.0 * c_PI;
	float outColorGreyVertical = sin(newValueX);
	float outColorGreyHorizontal = sin(newValueY);
	float newColor = max(outColorGreyVertical, outColorGreyHorizontal);
	FragColor = vec4(newColor);
}

void circle()
{
	vec2 temp = v_Texcoord - u_Points[0];
	float d = length(temp);
	vec2 temp1 = v_Texcoord - u_Points[1];
	float d1 = length(temp1);
	if(d<0.1 || d1<0.1)
	{
		FragColor = vec4(1);
	}
	else
	{
		FragColor = vec4(0);
	}
}

void circles()
{
	vec2 temp = v_Texcoord - u_Points[0];
	float d = length(temp); 
	float value = sin(30*d);

	FragColor = vec4(value);
}

void radar()
{
	vec2 temp = v_Texcoord - vec2(0.5, 1.0);
	float d = length(temp); 
	float value = 0.2*(pow(sin(d*2*c_PI - 50*u_Time), 12)-0.5);
	float temp1 = ceil(value);

	vec4 result = vec4(0);
	for(int i=0; i<3; i++)
	{
		vec2 temp = v_Texcoord - u_Points[i];
		float d = length(temp);

		if(d<0.03)
		{
			result += 1.0*temp1;
		}
	}
	


	FragColor = vec4(result + 10*value);
}

void flag()
{
	float finalColor = 0;
	for(int i=0; i<10; i++)
	{
		float newTime = u_Time + i*0.2;
		float newColor = v_Texcoord.x*0.5*
				sin(v_Texcoord.x*c_PI*2 - 10*newTime);
		float sinValue = sin(v_Texcoord.x*c_PI*2*10 - 500*newTime);
		float width = 0.01*v_Texcoord.x*5+0.001;
		if(2.0*(v_Texcoord.y-0.5) > newColor && 
		   2.0*(v_Texcoord.y-0.5) < newColor + width)
		{
			finalColor += 1*sinValue*(1.0-v_Texcoord.x);
		}
		else
		{
		}
	}
	FragColor = vec4(finalColor);
}

void main()
{
	//test();
	//circle();
	//circles();
	//radar();
	flag();
}
