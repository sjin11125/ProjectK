const { randomInt, randomBytes } = require('crypto');
const { Socket } = require('engine.io');
const { json, type } = require('express/lib/response');
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

http.listen(4444,()=>{
    console.log('서버 시작~~');
    
});

io.on('connection',(socket)=>{          //클라와 연결되면

console.log('연결된 유저: '+socket.id);

let Roomid; 

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
     socket.Roomid=id;
socket.emit('CreateRoom',id);           //쌍따옴표 없음
});


socket.on('EnterRoom',(id)=>{           //방 들어가기
    console.log('들어가는 방 id: '+id);
    
    socket.join(id);       //룸 드가기

    
    socket.Roomid=id;
    io.to(socket.Roomid).emit('EnterRoom',id);       //룸에 있는 사람들에게 보내기 게임 스타트
});

socket.on('MovePlayer',(pos)=>{           //캐릭터 움직이기
    //console.log('이동하는 방향: '+JSON.stringify( pos));
const posInfo=JSON.parse(JSON.stringify( pos));

posInfo.RoomId=posInfo.RoomId.replaceAll("\"", "");     //큰따옴표 제거


   io.to(posInfo.RoomId).emit('MoveOtherPlayer',posInfo);    
});

socket.on('GetItem',(index)=>{           //아이템 획득하기
 
   socket.to(socket.Roomid).emit('GetItem',index);    
   //다른 플레이어에게 획득한 아이템의 인덱스 전송
});

socket.on('Attack',(damage)=>{           //공격
    console.log('공격당함');

 
   io.to(socket.Roomid).emit('Attacked',damage);    
});

socket.on('SkillUpdate',(skill)=>{           //스킬 업데이트
    console.log('스킬 업데이트');
    const skillInfo=JSON.parse(JSON.stringify( skill));
 
   socket.to(socket.Roomid).emit('SkillUpdate',skillInfo);    
});

socket.on('SendMessage',(message)=>{           //채팅 보내기
    console.log('채팅');
    const chatInfo=JSON.parse(JSON.stringify( message));
 
    io.to(socket.Roomid).emit('RecieveMessage',chatInfo);    
    //룸에 있는 모든 유저에게 메세지 보냄
});


socket.on('Ready',()=>{           //레디
    console.log('레디');
 
   socket.to(socket.Roomid).emit('Ready','레디');    
});


socket.on('GameStart',()=>{           //게임 시작
    console.log('게임 시작');
    var seed=randSeed();            //랜덤 시드 정하기
    io.to(socket.Roomid).emit('GameStart',seed);    
 });
});

function randSeed()
{
    return Math.floor(Math.random() * (5 - 1)) + 1;
}
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