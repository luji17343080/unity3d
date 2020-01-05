contract Strorage{
    mapping(address => uint256) public balances; 
    function deposit() public payable {
        balances[msg. sender] += msg.value;
    }
    function withdraw(uint256 withdrawAmount) public {
        require(balances[msg.sender] >= withdrawAmount);
        require(this.balance > withdrawAmount);
        require(msg.sender.call.value(withdrawAmount)());
        balances[msg.sender] -= withdrawAmount;
    }
}
