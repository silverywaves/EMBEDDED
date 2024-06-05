package com.example.demo.restconstroller;


import com.fazecast.jSerialComm.SerialPort;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;
import java.io.*;

@RestController
@Slf4j
@RequestMapping("/arduino")
public class ArduinoRestController {

    private SerialPort serialPort;
    private OutputStream outputStream;
    private InputStream inputStream;

    private String LedLog;
    private String TmpLog;
    private String LightLog;
    private String DistanceLog;

    @GetMapping("/connection/{COM}")  // /arduino/connection/{COM} 경로에 대한 GET 요청 처리 메소드
    public ResponseEntity<String> setConnection(@PathVariable("COM") String COM, HttpServletRequest request) {
        log.info("GET /arduino/connection " + COM + " IP: " + request.getRemoteAddr());     // 로그 출력

        if (serialPort != null) {   // 만약 serialPort 가 null 이 아니라면(열려있다면)
            serialPort.closePort(); // serialPort를 닫고
            serialPort = null;      // serialPort를 null 로 초기화
        }

        //Port Setting
        serialPort = SerialPort.getCommPort(COM);   // 포트 연결을 위한 객체 생성

        //Connection Setting
        serialPort.setBaudRate(9600);   // 통신 속도를 9600으로 설정
        serialPort.setNumDataBits(8);   // 데이터 비트를 8로 설정
        serialPort.setNumStopBits(0);   // 스탑 비트를 0으로 설정
        serialPort.setParity(0);        // 패리티를 없음으로 설정
        serialPort.setComPortTimeouts(SerialPort.TIMEOUT_READ_BLOCKING,2000,0);
        // 시리얼 포트 열기
        boolean isOpen = serialPort.openPort(); // 시리얼 포트 열기 시도
        log.info("isOpen ? " + isOpen);     // 성공 여부 로그 출력


        if (isOpen) {   // 시리얼 포트 연결 성공시
            this.outputStream = serialPort.getOutputStream();   // 출력 스트림 설정
            this.inputStream = serialPort.getInputStream(); // 입력 스트림 설정

            //----------------------------------------------------------------
            //수신 스레드 동작
            //----------------------------------------------------------------
            Worker worker = new Worker();   // 수신스레드를 위한 worker 객체 생성
            Thread th = new Thread(worker); // 스레드 생성
            th.start(); // 스레드 실행


            return new ResponseEntity("Connection Success!", HttpStatus.OK);    // 연결 성공 응답
        } else {        // 시리얼 포트 연결 실패시
            return new ResponseEntity("Connection Fail...!", HttpStatus.BAD_GATEWAY);  // 연결 실패 응답
        }


    }

    @GetMapping("/led/{value}") // /arduino/led/{value} 경로에 대한 GET 요청 처리 메소드
    public void led_Control(@PathVariable String value, HttpServletRequest request) throws IOException {
        log.info("GET /arduino/led/value : " + value + " IP : " + request.getRemoteAddr());
        if (serialPort.isOpen()) {  // 시리얼 포트가 열려있는 경우
            outputStream.write(value.getBytes());   // 값을 시리얼 포트로 전송
            outputStream.flush();   // 출력 스트림 비우기
        }
    }

    @GetMapping("/message/led") // /arduin/message/led 경로에 대한 GET 요청 처리 메소드
    public String led_Message() throws InterruptedException {
        return LedLog;  // LED 로그 반환
    }

    @GetMapping("/message/tmp") // /arduino/message/tmp 경로에 대한 GET 요청 처리 메소드
    public String tmp_Message() {
        return TmpLog;  // 온도 로그 반환
    }

    @GetMapping("/message/light")   // /arduino/message/light 경로에 대한 GET 요청 처리 메소드
    public String light_Message() {
        return LightLog;    // 조도 로그 반환
    }

    @GetMapping("/message/distance")    // /arduino/message/distance 경로에 대한 GET 요청 처리 메소드
    public String distance_Message() {
        return DistanceLog; // 거리 로그 반환
    }




    //----------------------------------------------------------------
    // 수신 스레드 클래스
    //----------------------------------------------------------------
    class Worker implements Runnable {
        DataInputStream din;    // 데이터 입력 스트림
        @Override
        public void run() {
            din = new DataInputStream(inputStream); // 입력 스트림 초기화
            try{
                while(!Thread.interrupted()) {  // 스레드가 종료되지 않는 동안 반복
                    if (din != null) {  // 입력 스트림이 null이 아닌 경우
                        String data = din.readLine();   // 데이터를 읽음
                        System.out.println("[DATA] : " + data); // 데이터 출력
                        String[] arr = data.split("_"); // 데이터를 '_'를 기준으로 분할
                        try {
                            if (arr.length > 3) {   // 분할된 데이터의 길이가 3보다 크면
                                LedLog = arr[0];    // 첫번째 배열에 LED 로그 설정
                                TmpLog = arr[1];    // 두번째 배열에 온도 로그 설정
                                LightLog = arr[2];  // 세번째 배열에 조도 로그 설정
                                DistanceLog = arr[3];   // 네번째 배열에 거리 로그 설정
                            } else {    // 분할된 데이터의 길이가 3보다 작으면
                                TmpLog = arr[0];    // 첫번째 배열에 온도 로그 설정
                                LightLog = arr[1];  // 첫번째 배열에 조도 로그 설정
                                DistanceLog = arr[2];   // 첫번째 배열에 거리 로그 설정
                            }
                        }catch(ArrayIndexOutOfBoundsException e1){e1.printStackTrace();}
//                        if(data.startsWith("LED:")){
//                            LedLog = data;
//                        }else if(data.startsWith("TMP:")) {
//                            TmpLog = data;
//                        }else if(data.startsWith("LIGHT:")){
//                            LightLog = data;
//                        }else if(data.startsWith("DIS:")){
//                            DistanceLog = data;
//                        }
                    }
                    Thread.sleep(200);  // 대기
                }
            }catch(Exception e){
                e.printStackTrace();
            }
        }
    }
    //----------------------------------------------------------------

}











