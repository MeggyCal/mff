#version 300 es
precision mediump float;

in vec2 fragTexCoord;
in vec3 fragNormal;
in vec3 fragPosition;

out vec4 FragColor;

uniform sampler2D sampler;

void main()
{
	vec4 texture = texture(sampler, fragTexCoord);
	FragColor = vec4( 1.0-vec3(fragPosition.z/10.0), 1);
}