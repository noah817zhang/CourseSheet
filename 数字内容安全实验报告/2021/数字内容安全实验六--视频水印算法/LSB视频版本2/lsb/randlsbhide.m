%文件名:randlsbhide.m
%程序员:李巍
%编写时间:2004.3.2
%函数功能:本函数将完成随机选择LSB的信息隐秘
%输入格式举例:[ste_cover,len_total]=randlsbhide('lena.bmp','message.txt','hided.bmp',213)
%参数说明:
%input是信息隐蔽载体图像
%file是秘密消息文件
%output是信息隐秘后生成图像
%key是随机间隔函数的密钥 
%ste_cover是信息隐秘后图像矩阵 
%len_total是秘密消息的长度，即容量
function  [ste_cover,len_total]=randlsbhide(input,file,output,key)
%读入图像矩阵

ste_cover=input;
ste_cover=double(ste_cover);
%将文本文件转换为二进制序列
f_id=fopen(file,'r');
[msg,len_total]=fread(f_id,'ubit1'); 
%判断嵌入消息量是否过大
[m,n]=size(ste_cover);
if len_total>m*n
    error('嵌入消息量过大，请更换图像');
end
%p作为消息嵌入位数计数器
p=1;
%调用随机间隔函数选取像素点 
[row,col]=randinterval(ste_cover,len_total,key);
%在LSB隐秘消息 
for i=1:len_total
   ste_cover(row(i),col(i))=ste_cover(row(i),col(i))-mod(ste_cover(row(i),col(i)),2)+msg(p,1);
 if p==len_total
   break;
 end
 p=p+1;
end
ste_cover=uint8(ste_cover);
imwrite(ste_cover,output);
%显示实验结果 


