precision mediump float;

varying vec2 fragTexCoord;
varying vec3 fragNormal;
varying vec3 fragPosition;

uniform sampler2D sampler;

void main()
{
	vec4 texture = texture2D(sampler, fragTexCoord);
	gl_FragColor = vec4( 1.0-vec3(fragPosition.z/10.0), 1);
}