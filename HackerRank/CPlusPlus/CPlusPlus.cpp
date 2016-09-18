// CPlusPlus.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <queue>
#include <iostream>

int maxXor(int l, int r) {
	if (l == r) return 0;
	int flag = 1;
	int max = ~0;
	int min = 0;

	//while((flag & r) <= flag){
	while (flag < r) {
		if (((l & r) & flag) == flag) {
			if ((r ^ flag) < l) {
				flag = flag << 1;
				continue;
			}
			else
				r = r ^ flag;
		}
		else if ((l & flag) == 0 && (r & flag) == 0) {
			if ((l | flag) > r) {
				flag = flag << 1;
				continue;
			}
			else {
				l = l | flag;
			}
		}

		flag = flag << 1;
	}

	int temp = l ^ r;

	return l ^ r;
	//return r;
}


int main()
{
	//std::queue<int> blah;
	int res;
	int _l = 10;

	int _r = 15;

	res = maxXor(_l, _r);
	std::cout << res;

	return 0;

    return 0;
}

void LevelOrder(int root)
{
	std::queue<int> q;
	q.push(root);
}



