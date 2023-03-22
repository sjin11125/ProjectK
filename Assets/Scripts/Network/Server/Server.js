const { randomInt, randomBytes } = require('crypto');
const { Socket } = require('engine.io');
const { json } = require('express/lib/response');
const {crypto}=require('crypto');
const e = require('express');
const { Console } = require('console');

const app=require('express')();
const http=require('http').createServer(app);
const io=require('socket.io')(http);

let rooms=[];       //현재 생성된 룸id들

app.get('/', (req, res) => {
    res.send('Hello');
 });

http.listen(8000,()=>{console.log('서버 시작~~')});

io.on('connection',(socket)=>{          //클라와 연결되면

console.log('연결된 유저: '+socket.id);

socket.on('CreateRoom',()=>{            //방 생성할거니까 룸 id 생성해달라고 클라가 요청
//방 생성 후 플레이어 참가
//룸ID 만듬(랜덤 )
var id;
     if(rooms.length==0)      //룸이 아예 없다면
     {
        id=makeid(); 
     
      rooms[rooms.length]=id;          //현재 생성된 방들
     }
     else   
     {
      do {
        id=makeid();        //룸 id 설정
        } while (detectDup(id));    //룸id 중복 안될 때까지
        rooms[rooms.length]=id;
     }

     socket.join(id);       //룸 드가기
     console.log('생성된 방 id: '+ id);
socket.emit('CreateRoom',id);
});


socket.on('EnterRoom',(id)=>{
    console.log('들어가는 방 id: '+id);
    
    socket.join(id);       //룸 드가기
   io.to(id).emit('GameStart',id);       //룸에 있는 사람들에게 보내기 게임 스타트
});



});


function detectDup(id)     //룸 id 중복되는지 확인하는 함수, 중복되면 false, 중복안되면 true
{
   rooms.forEach(element => {
      if(element.roomId!=id)
      {
          return false;
      }
       
       else 
       return true;
   });
}
function makeid()           //id랜덤 생성                                  
{
    var text = "";
    var possible = "0123456789";

   for( var i=0; i < 6; i++ )
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    
    return text;
}