#version 300 es
precision mediump float;

in vec2 vertCoordinates;

uniform sampler2D uPositionBuffer;
uniform sampler2D uNormalBuffer;
uniform sampler2D uUVBuffer;

out vec4 FragColor;

void main()
{
	vec4 texPos = texture(uPositionBuffer, vertCoordinates);
	vec4 texNormal = texture(uNormalBuffer, vertCoordinates);
	vec4 texUV = texture(uUVBuffer, vertCoordinates);
	FragColor = vec4(texUV.rgb, 1.0);
}