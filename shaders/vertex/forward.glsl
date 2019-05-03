#version 300 es
precision mediump float;

in vec3 vertPosition;
in vec2 vertTexCoord;
in vec3 vertNormal;

out vec4 fragTexCoord;
out vec4 fragNormal;
out vec4 fragPosition;

uniform mat4 mWorld;
uniform mat4 mView;
uniform mat4 mProj;

void main()
{
  fragTexCoord = vec4(vertTexCoord, 0.0, 0.0);
  fragNormal = vec4((mWorld * vec4(vertNormal, 0.0)).xyz, 0.0);

  gl_Position = mProj * mView * mWorld * vec4(vertPosition, 1.0);
  fragPosition = vec4(gl_Position.xyz, 0.0);
}