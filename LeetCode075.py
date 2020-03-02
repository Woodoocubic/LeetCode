class Solution:
    def sortColors(self, nums: List[int]):
        p, q = 0, 0
        k = len(nums)-1

        while q<=k:
            if p<q and nums[q] == 0:
                nums[p], nums[q] = nums[q], nums[p]
                p += 1
            elif q<k and nums[q] == 2:
                nums[k], nums[q] = nums[q], nums[k]
                k -= 1
            else:
                q +=1
