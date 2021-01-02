// +build wireinject
// The build tag makes sure the stub is not built in the final build.

package di

import (
	"libra-coffee-backend/internal/dao"
	"libra-coffee-backend/internal/server/grpc"
	"libra-coffee-backend/internal/server/http"
	"libra-coffee-backend/internal/service"

	"github.com/google/wire"
)

//go:generate kratos t wire
func InitApp() (*App, func(), error) {
	panic(wire.Build(dao.Provider, service.Provider, http.New, grpc.New, NewApp))
}
