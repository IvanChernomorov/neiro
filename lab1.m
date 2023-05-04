ans = TestFunc(pi/3);
x = -2*pi:pi/30:4*pi;
y = TestFunc(x);
plot(x,y);
xlabel('X');
ylabel('Y');