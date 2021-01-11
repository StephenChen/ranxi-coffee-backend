package model

import "github.com/go-kratos/kratos/pkg/time"

// Kratos hello kratos.
type Kratos struct {
	Hello string
}

type Article struct {
	ID      int64
	Content string
	Author  string
}

type Coffee struct {
	ID    int32
	Name  string
	Price int32
}

type Order struct {
	ID         int32
	CreateTime time.Duration
	UpdateTime time.Duration
}
