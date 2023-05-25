t=3.1:0.1:20;
L = length(t);
z=t .* sin(t)+0.2*randn(1,L);
train_size = 170;
x=[ 0 z(1:train_size-1); 
    0 0 z(1:train_size-2); 
    0 0 0 z(1:train_size-3); 
    0 0 0 0 z(1:train_size-4);
    0 0 0 0 0 z(1:train_size-5)]; 

net = feedforwardnet([50 1]);
net.layers{1}.transferFcn = 'tansig';
net.layers{2}.transferFcn = 'purelin';
net = train(net, x, z(1:train_size));

y = sim(net, x);
n = length(y);

for i=1:50
    y(n+i)=sim(net, y(n+i-1:-1:n+i-5)');
end
plot(z, 'b'), hold on, grid on
plot(y, 'r'), hold off 
