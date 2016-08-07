t = delay;
m = dimension;
paka = iterate;
N = floor(length(sig)*percent);
% new signal array
new_sig = zeros(N + paka, 1);
% loop old signals into new signal array
for k = 1:N
    new_sig(k,1) = sig(k);
end
% create vector matrix
dimension_bin = zeros(N - (m - 1) * t, m);
for k = 1:(N - (m - 1) * t)
    for p = 1:m
        dimension_bin(k,p) = sig(k + (p - 1) * t);
    end
end
for k = 1:paka
   new_pos = N + k;
   prev_value = new_sig(new_pos - 1);
   prev_pos = new_pos - 1;
   recons_vector = zeros(1,m);
   % reconstruct the vector of the previous value
   for i = 1:m
      recons_vector(1, i) = new_sig(prev_pos - ((m - i)*t), 1);      
   end
   % innitiate smallest distance, save the location of this value
   sml_dist = 1000000000000000000;
   sml_dist_locs = 1;
   % loop to find the nearest neighbor in the bin dimension matrix
   for bin_locs = 1: (N - (m - 1) * t - 1)
       locted_bin = zeros(1, m);
       % loop current vector into loced_bin
       for j = 1:m
          locted_bin(1, j) = dimension_bin(bin_locs, j); 
       end
       % find the distance between locted_bin and recons_vector
       square = 0;
       for j = 1:m
          square = square + (recons_vector(1,j) - locted_bin(1,j))^2;
       end
       dist = sqrt(square);
       % check if smallest
       if dist < sml_dist
          sml_dist = dist;
          sml_dist_locs = bin_locs;
       end
   end
   new_sig(new_pos) = dimension_bin(sml_dist_locs + 1, m);
end
plot(sig)
hold on
plot(new_sig)


