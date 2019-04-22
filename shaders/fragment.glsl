precision mediump float;

struct DirectionalLight
{
	vec3 direction;
	vec3 color;
};

varying vec2 fragTexCoord;
varying vec3 fragNormal;

vec3 ambientLightIntensity 	= vec3(0.2, 0.2, 0.2);
DirectionalLight sun 		= DirectionalLight(normalize(vec3( 0.0, 0.0,-1.0)), vec3(0.8, 0.8, 0.8));
DirectionalLight sunRed 	= DirectionalLight(normalize(vec3(-1.0, 0.0, 0.0)), vec3(1.0, 0.0, 0.0));
DirectionalLight sunGreen 	= DirectionalLight(normalize(vec3( 0.0,-1.0, 0.0)), vec3(0.0, 1.0, 0.0));
DirectionalLight sunBlue 	= DirectionalLight(normalize(vec3( 0.0, 1.0,-1.0)), vec3(0.0, 0.0, 1.0));
uniform sampler2D sampler;

#define realistic 0

void main()
{
	vec3 surfaceNormal = normalize(fragNormal);
	vec4 texture = texture2D(sampler, fragTexCoord);
#if realistic
	vec3 lightIntensity =
		ambientLightIntensity +
		sun.color 	* max(dot(fragNormal, sun.direction	), 0.0);
	gl_FragColor = vec4(texture.rgb * lightIntensity, texture.a);
#else
	vec3 lightIntensity = 
		ambientLightIntensity +
		sunRed.color 	* max(dot(fragNormal, sunRed.direction	), 0.0)+
		sunGreen.color 	* max(dot(fragNormal, sunGreen.direction), 0.0)+
		sunBlue.color 	* max(dot(fragNormal, sunBlue.direction	), 0.0);
	gl_FragColor = texture.rgba;
	//gl_FragColor = vec4(vec3(0.6, 0.6, 0.6) * lightIntensity, texture.a);
#endif
}