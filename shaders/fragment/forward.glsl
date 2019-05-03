#version 300 es
precision mediump float;

struct light
{
	vec3 direction;
	vec3 color;
};

in vec4 fragTexCoord;
in vec4 fragNormal;
in vec4 fragPosition;

uniform sampler2D sampler;

out vec4 FragColor;

vec3 ambientLightIntensity 	= vec3(0.2, 0.2, 0.2);
light sun 		= light(normalize(vec3( 0.0, 0.0,-1.0)), vec3(0.8, 0.8, 0.8));


void main()
{
	vec4 texture = texture(sampler, fragTexCoord.xy);
	vec3 lightIntensity =
		ambientLightIntensity +
		sun.color 	* max(dot(fragNormal.xyz, sun.direction	), 0.0);
	FragColor = vec4(texture.rgb * lightIntensity, texture.a);
}