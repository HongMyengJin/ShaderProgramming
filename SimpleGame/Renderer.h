#pragma once

#include <string>
#include <cstdlib>
#include <fstream>
#include <iostream>

#include "Dependencies\glew.h"

class Renderer
{
public:
	Renderer(int windowSizeX, int windowSizeY);
	~Renderer();

	bool IsInitialized();
	void DrawSolidRect(float x, float y, float z, float size, float r, float g, float b, float a);
	void Class0310_Render();
	void DrawParticleEffect();
	void DrawFragmentSandbox();
	void DrawAlphaClear();
	void DrawVertexSandbox();
	void DrawTextureSandbox();

private:
	void Initialize(int windowSizeX, int windowSizeY);
	bool ReadFile(char* filename, std::string *target);
	void AddShader(GLuint ShaderProgram, const char* pShaderText, GLenum ShaderType);
	GLuint CompileShaders(char* filenameVS, char* filenameFS);
	void CreateVertexBufferObjects();
	void GetGLPosition(float x, float y, float *newX, float *newY);
	void Class0310();
	void CreateTextures();
	GLuint CreatePngTexture(char* filePath, GLuint samplingMethod);

	//particle VBO
	void CreateParticles(int numParticles);
	GLuint m_ParticleVBO = -1;
	GLuint m_ParticleVelVBO = -1;
	GLuint m_ParticleEmitTimeVBO = -1;
	GLuint m_ParticleLifeTimeVBO = -1;
	GLuint m_ParticlePeriodVBO = -1;
	GLuint m_ParticleAmpVBO = -1;
	GLuint m_ParticleValueVBO = -1;
	GLuint m_ParticleColorVBO = -1; //particle color vbo
	GLuint m_ParticlePositionColorVelUVVBO = -1; //pos+color+vel vbo
	GLuint m_ParticleShader = -1;
	GLuint m_ParticleVerticesCount = -1;

	bool m_Initialized = false;
	
	unsigned int m_WindowSizeX = 0;
	unsigned int m_WindowSizeY = 0;

	GLuint m_VBORect = 0;
	GLuint m_SolidRectShader = 0;

	GLuint m_testVBO = 0;
	GLuint m_testVBO1 = 0;
	GLuint m_testVBOColor = 0;

	GLuint m_FragmentSandboxShader = 0;
	GLuint m_FragmentSandboxVBO = 0;

	GLuint m_AlphaClearShader = 0;
	GLuint m_AlphaClearVBO = 0;

	GLuint m_VertexSandboxShader = 0;
	GLuint m_HoriLineVBO = 0;
	GLuint m_HoriLineVertexCount = 0;

	GLuint m_TextureSandboxShader = 0;
	GLuint m_TextureSandbox = 0;
	GLuint m_TextureSandboxVBO = 0;
	GLuint m_CheckerBoardTexture = 0;
	GLuint m_RGBTexture = 0;
};

