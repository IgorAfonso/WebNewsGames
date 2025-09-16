package newsHandler

type CreateNewsObject struct {
	Title         string `json:"title"`
	FirstContent  string `json:"firstContent"`
	SecondContent string `json:"secondContent"`
	ThirdContent  string `json:"thirdContent"`
}

type UpdateNewsObject struct {
	Title         string `json:"title"`
	FirstContent  string `json:"firstContent"`
	SecondContent string `json:"secondContent"`
	ThirdContent  string `json:"thirdContent"`
}