precision mediump float;

struct light
{
	vec3 direction;
	vec3 color;
};

varying vec2 fragTexCoord;
varying vec3 fragNormal;

vec3 ambientLightIntensity 	= vec3(0.2, 0.2, 0.2);
light sun 		= light(normalize(vec3( 0.0, 0.0,-1.0)), vec3(0.8, 0.8, 0.8));
light sunRed 	= light(normalize(vec3(-1.0, 0.0, 0.0)), vec3(1.0, 0.0, 0.0));
light sunGreen 	= light(normalize(vec3( 0.0,-1.0, 0.0)), vec3(0.0, 1.0, 0.0));
light sunBlue 	= light(normalize(vec3( 0.0, 1.0,-1.0)), vec3(0.0, 0.0, 1.0));
uniform sampler2D sampler;


void main()
{
	vec3 surfaceNormal = normalize(fragNormal);
	vec4 texture = texture2D(sampler, fragTexCoord);
	vec3 lightIntensity = 
		sunRed.color 	* max(dot(fragNormal, sunRed.direction	), 0.0)+
		sunGreen.color 	* max(dot(fragNormal, sunGreen.direction), 0.0)+
		sunBlue.color 	* max(dot(fragNormal, sunBlue.direction	), 0.0);
	gl_FragColor = vec4(lightIntensity, 1);

}