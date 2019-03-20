const canvas = document.getElementById('canvas');
const gl = canvas.getContext("webgl2")


let vertexShaderText =  require('shaders/vertexShader.txt');
console.log(vertexShaderText)
