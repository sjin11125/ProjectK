const { randomInt, randomBytes } = require('crypto');
const { Socket } = require('engine.io');
const { json } = require('express/lib/response');
const {crypto}=require('crypto');
const e = require('express');
const { Console } = require('console');

const app=require('express')();
const http=require('http').createServer(app);
const io=require('socket.io')(http);

app.get('/', (req, res) => {
    res.send('Hello');
 });

http.listen(8000,()=>{console.log('서버 시작~~')});

io.on('connection',(socket)=>{          //클라와 연결되면

console.log('연결된 유저: '+socket.id);


});